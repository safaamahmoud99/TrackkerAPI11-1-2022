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
    public class OrganizationClientsRepository : IOrganizationClientsRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganizationClientsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(OrganizationClientsDTO organizationClientsDTO)
        {
            try
            {
                if (organizationClientsDTO != null)
                {
                    foreach (var item in organizationClientsDTO.Clients)
                    {
                        OrganizationClients organizationClients = new OrganizationClients();
                        organizationClients.OrganizationId = organizationClientsDTO.OrganizationId;
                        organizationClients.ClientId = item.Id;
                        _context.OrganizationClients.Add(organizationClients);
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

        public IEnumerable<OrganizationClientsDTO> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ProjectDTO> GetOrganizationProjectsByClientId(int ClientId)
        {
            OrganizationClients organizationClients = _context.OrganizationClients.Where(a => a.ClientId == ClientId).FirstOrDefault();
            if (organizationClients == null)
            {
                return null;
                //throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var proj = _context.projects.Where(e => e.IsDeleted == false && e.OrganizationId== organizationClients.OrganizationId).Select(e => new ProjectDTO
                {
                    Id = e.Id,
                    ProjectName = e.ProjectName,
                    ProjectCode = e.ProjectCode,
                    Cost = e.Cost,
                    ProjectTypeId = e.ProjectTypeId,
                    ProjectTypeName = e.ProjectType.TypeName,
                    ProjectPeriod = e.ProjectPeriod,
                //    PlanndedStartDate = e.PlanndedStartDate,
                    PlanndedEndDate = e.PlanndedEndDate,
                    ActualStartDate = e.ActualStartDate,
                    ActualEndDate = e.ActualEndDate,
                    Description = e.Description,
                    OrganizationId = e.OrganizationId,
                    OrganizationName = e.Organization.OrganizationName,
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.Employee.EmployeeName,                   
                }).OrderByDescending(p => p.Id).ToList();
                return proj;

                //var organization = new Organization
                //{
                //    Id = organizationClients.OrganizationId,
                //    OrganizationName = organizationClients.Organization.OrganizationName,
                //    Address = organizationClients.Organization.Address,
                //    OrganizationCode = organizationClients.Organization.OrganizationCode
                //};
                //return organization;
            }
        }
        public IEnumerable<Client> GetAllAssignedClientsByOrganizationId(int OrganizationId)
        {
            var assignClients = _context.OrganizationClients.Where(sc => sc.OrganizationId == OrganizationId).Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName,
                //Email = sClient.Client.Email,
                //Phone = sClient.Client.Phone,
                //Address = sClient.Client.Address
            }).ToList();
            return assignClients;
        }
        public IEnumerable<Client> GetAllAssignedClientsDataByOrganizationId(int OrganizationId)
        {
            var assignClients = _context.OrganizationClients.Where(sc => sc.OrganizationId == OrganizationId).Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName,
                Email = sClient.Client.Email,
                Phone = sClient.Client.Phone,
                Address = sClient.Client.Address
            }).ToList();
            return assignClients;
        }
        public IEnumerable<Client> GetAllUnassignedClients()
        {
            List<Client> LstUnassignedClients = _context.clients.ToList();

            var AllassignClients = _context.OrganizationClients.Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName,
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

            return LstUnassignedClients;
        }

        public IEnumerable<Client> GetAllUnassignedClientsforAnotherOrganizationAndAssignedByThisOrganizationId(int OrganizationId)
        {
            List<Client> LstUnassignedClients = _context.clients.ToList();
            var assignClients = _context.OrganizationClients.Where(sc => sc.OrganizationId == OrganizationId).Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName,
            }).ToList();

            var AllassignClientsForAnother = _context.OrganizationClients.Where(sc => sc.OrganizationId != OrganizationId).Select(sClient => new Client
            {
                Id = sClient.ClientId,
                ClientName = sClient.Client.ClientName
            }).ToList();

            var clients = _context.clients.ToList();
            foreach (var client in clients)
            {
                foreach (var assignClient in AllassignClientsForAnother)
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

        public async Task<IEnumerable<OrganizationClients>> UpdateByOrganizationId(int OrganizationId, List<Client> clients)
        {
            if (OrganizationId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            List<OrganizationClients> lstorganizationClients = new List<OrganizationClients>();
            try
            {
                if (clients != null)
                {
                    List<int> modelClientIds = clients.OrderBy(a => a.Id).Select(a => a.Id).ToList();

                    List<int> savedClientIds = _context.OrganizationClients
                        .Where(a => a.OrganizationId == OrganizationId).OrderBy(a => a.ClientId).Select(a => a.ClientId).ToList();

                    List<int> deletedClientIds = savedClientIds.Except(modelClientIds).ToList();
                    if (deletedClientIds.Count > 0)
                    {
                        foreach (var clientId in deletedClientIds)
                        {
                            lstorganizationClients = _context.OrganizationClients.Where(a => a.ClientId == clientId && a.OrganizationId == OrganizationId).ToList();
                            if (lstorganizationClients.Count > 0)
                            {
                                OrganizationClients organizationClients = lstorganizationClients[0];
                                if (organizationClients != null)
                                {
                                    _context.Entry(organizationClients).State = EntityState.Deleted;

                                    _context.SaveChanges();
                                }
                            }
                        }
                    }

                    List<int> savedClientsId2 = await _context.OrganizationClients.Where(a => a.OrganizationId == OrganizationId)
                                                      .OrderBy(a => a.ClientId).Select(a => a.ClientId).ToListAsync();

                    var added = modelClientIds.Except(savedClientsId2).ToList();
                    if (added.Count > 0)
                    {
                        foreach (var item in added)
                        {
                            OrganizationClients organizationClients = new OrganizationClients();
                            organizationClients.OrganizationId = OrganizationId;
                            organizationClients.ClientId = item;
                            _context.OrganizationClients.Add(organizationClients);
                            _context.SaveChanges();
                        }
                    }
                    else
                    {
                        foreach (var item in clients)
                        {

                            lstorganizationClients = _context.OrganizationClients.Where(a => a.OrganizationId == OrganizationId && a.ClientId == item.Id).ToList();
                            if (lstorganizationClients.Count == 0)
                            {
                                OrganizationClients organizationClients = new OrganizationClients();
                                organizationClients.OrganizationId = OrganizationId;
                                organizationClients.ClientId = item.Id;
                                _context.OrganizationClients.Add(organizationClients);
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
            return lstorganizationClients;
        }
    }
}
