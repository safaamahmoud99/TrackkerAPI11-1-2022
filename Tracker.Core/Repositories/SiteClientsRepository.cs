using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class SiteClientsRepository : ISiteClientsRepository
    {
        private readonly ApplicationDbContext _context;

        public SiteClientsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(SiteClientsDTO SiteClientsDTO)
        {
            try
            {
                if (SiteClientsDTO != null)
                {
                    foreach (var item in SiteClientsDTO.Clients)
                    {
                        SiteClients siteClients = new SiteClients();
                        siteClients.ProjectSiteId = SiteClientsDTO.ProjectSiteId;
                        siteClients.ClientId = item.Id;
                        _context.SiteClients.Add(siteClients);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteClientsDTO> GetAll()
        {
            var siteclients = _context.SiteClients.Select(sitecln => new SiteClientsDTO
            {
                Id = sitecln.Id,
                //SiteId = sitecln.SiteId,
                //SiteName = sitecln.Sites.Sitename,
            }).ToList();
            return siteclients;   //not completed implementation
        }

        public IEnumerable<Client> GetAllAssignedClients(int SiteId, int ProjectId)
        {
            //var sitesByProjectId = _context.ProjectSites.Where(ps => ps.ProjectId == ProjectId && ps.SiteId== SiteId).ToList();
            var assignClients = _context.SiteClients.Where(sc => sc.ProjectSites.SiteId == SiteId && sc.ProjectSites.ProjectId == ProjectId).Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName
            }).ToList();
            return assignClients;

        }
        public IEnumerable<ClientDTO> GetAllAssignedClientsByProjectId(int ProjectId)
        {
            var assignClients = _context.SiteClients.Where(sc => sc.ProjectSites.ProjectId == ProjectId).Select(sClient => new ClientDTO
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName,
                Email= sClient.Client.Email,
                Phone=sClient.Client.Phone,
                Address=sClient.Client.Address

            }).ToList();
            return assignClients;

        }
        public IEnumerable<Client> GetAllUnassignedClients(int SiteId, int ProjectId)
        {
            var sitesByProjectId = _context.ProjectSites.Where(ps => ps.ProjectId == ProjectId).ToList();
            List<Client> LstUnassignedClients = _context.clients.ToList();

            foreach (var item in sitesByProjectId)
            {
                var assignClients = _context.SiteClients.Where(sc => sc.ProjectSites.SiteId == SiteId && item.ProjectId == ProjectId).Select(sClient => new Client
                {
                    Id = sClient.ClientId,
                    ClientName = sClient.Client.ClientName
                }).ToList();
                var AllassignClients = _context.SiteClients.Where(sc => sc.ProjectSites.ProjectId != ProjectId).Select(sClient => new Client
                {
                    Id = sClient.ClientId,
                    ClientName = sClient.Client.ClientName
                }).ToList();
                foreach (var assigned in assignClients)
                {
                    AllassignClients.Add(assigned);
                }
                var clients = _context.clients.ToList();
                foreach (var client in clients)
                {
                    foreach (var assignClient in AllassignClients)
                    {
                        if (client.Id == assignClient.Id)
                        {
                            LstUnassignedClients.Remove(client);
                        }
                    }
                }
            }
            return LstUnassignedClients;
        }

        public IEnumerable<Client> GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId(int SiteId, int ProjectId)
        {
            List<Client> LstUnassignedClients = _context.clients.ToList();

            var assignClients = _context.SiteClients.Where(sc => sc.ProjectSites.SiteId == SiteId && sc.ProjectSites.ProjectId == ProjectId).Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName
            }).ToList();
            var AllassignClients = _context.SiteClients.Where(sc => sc.ProjectSites.ProjectId != ProjectId).Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName
            }).ToList();
            var clients = _context.clients.ToList();
            foreach (var client in clients)
            {
                foreach (var assignClient in AllassignClients)
                {
                    if (client.Id == assignClient.Id)
                    {
                        LstUnassignedClients.Remove(client);
                    }
                }
            }

            foreach (var assigned in assignClients)
            {

                LstUnassignedClients.Add(assigned);
            }

            var distinctItems = LstUnassignedClients.Except(LstUnassignedClients.GroupBy(i => i.Id)
                                             .Select(ss => ss.LastOrDefault()))
                                            .ToList();
            foreach (var item in distinctItems)
            {
                LstUnassignedClients.Remove(item);
            }
            return LstUnassignedClients;
        }

        public SiteClientsDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, SiteClientsDTO SiteClientsDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SiteClients>> UpdateByprojectSiteId(int projectSiteId, List<Client> clients)
        {

            if (projectSiteId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            List<SiteClients> lstSiteClients = new List<SiteClients>();
            try
            {
                if (clients != null)
                {
                    List<int> modelClientIds = clients.OrderBy(a => a.Id).Select(a => a.Id).ToList();

                    List<int> savedClientIds = _context.SiteClients
                        .Where(a => a.ProjectSiteId == projectSiteId).OrderBy(a => a.ClientId).Select(a => a.ClientId).ToList();

                    List<int> deletedClientIds = savedClientIds.Except(modelClientIds).ToList();
                    if (deletedClientIds.Count > 0)
                    {
                        foreach (var clientId in deletedClientIds)
                        {
                            lstSiteClients = _context.SiteClients.Where(a => a.ClientId == clientId && a.ProjectSiteId == projectSiteId).ToList();
                            if (lstSiteClients.Count > 0)
                            {
                                SiteClients siteClients = lstSiteClients[0];
                                if (siteClients != null)
                                {
                                    _context.Entry(siteClients).State = EntityState.Deleted;

                                    _context.SaveChanges();
                                }
                            }
                        }
                    }

                    List<int> savedClientsId2 = await _context.SiteClients.Where(a => a.ProjectSiteId == projectSiteId)
                                                      .OrderBy(a => a.ClientId).Select(a => a.ClientId).ToListAsync();

                    var added = modelClientIds.Except(savedClientsId2).ToList();
                    if (added.Count > 0)
                    {
                        foreach (var item in added)
                        {
                            SiteClients siteClients = new SiteClients();
                            siteClients.ProjectSiteId = projectSiteId;
                            siteClients.ClientId = item;
                            _context.SiteClients.Add(siteClients);
                            _context.SaveChanges();
                        }
                    }
                    else
                    {
                        foreach (var item in clients)
                        {

                            lstSiteClients = _context.SiteClients.Where(a => a.ProjectSiteId == projectSiteId && a.ClientId == item.Id).ToList();
                            if (lstSiteClients.Count == 0)
                            {
                                SiteClients siteClients = new SiteClients();
                                siteClients.ProjectSiteId = projectSiteId;
                                siteClients.ClientId = item.Id;
                                _context.SiteClients.Add(siteClients);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
            return lstSiteClients;

        }
    }
}


//foreach (var item in sitesByProjectId)
//{
//    var assignClients = _context.SiteClients.Where(sc => sc.ProjectSites.SiteId == SiteId && item.ProjectId == ProjectId).Select(sClient => new Client
//    {
//        Id = sClient.ClientId,
//        ClientName = sClient.Client.ClientName
//    }).ToList();
//    var clients = _context.clients.ToList();
//    foreach (var client in clients)
//    {
//        foreach (var assignClient in assignClients)
//        {
//            if (client.Id == assignClient.Id)
//            {
//                LstUnassignedClients.Remove(client);
//            }
//        }
//    }

//}