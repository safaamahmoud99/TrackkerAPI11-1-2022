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
    public class ProjectSiteAssetRepository : IProjectSiteAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectSiteAssetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectSiteAssetDTO ProjectSiteAssetDTO)
        {
            try
            {
                if (ProjectSiteAssetDTO != null)
                {
                        ProjectSiteAsset projectSiteAsset = new ProjectSiteAsset();
                        projectSiteAsset.Days = ProjectSiteAssetDTO.Days;
                        projectSiteAsset.SerialNumber = ProjectSiteAssetDTO.SerialNumber;
                        projectSiteAsset.WarrantyPeriod = ProjectSiteAssetDTO.WarrantyPeriod;
                        projectSiteAsset.WarrantyStartDate = ProjectSiteAssetDTO.WarrantyStartDate;
                        projectSiteAsset.AssetId = ProjectSiteAssetDTO.AssetId;
                        projectSiteAsset.SupplierId = ProjectSiteAssetDTO.SupplierId;
                        projectSiteAsset.ProjectSiteId = ProjectSiteAssetDTO.ProjectSiteId;
                        _context.ProjectSiteAsset.Add(projectSiteAsset);
                        _context.SaveChanges();
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
        public IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetBySiteId(int SiteId,int ProjectId) 
        {
            var LstProjectSiteAsset = _context.ProjectSiteAsset.Where(ps => ps.ProjectSites.SiteId == SiteId && ps.ProjectSites.ProjectId== ProjectId)
                 .Include(ps => ps.ProjectSites).Include(ps=>ps.Asset).Include(ps=>ps.Supplier).Select(projectSiteAsset => new ProjectSiteAssetDTO
                 {
                     Id= projectSiteAsset.Id,
                     Days = projectSiteAsset.Days,
                     SerialNumber= projectSiteAsset.SerialNumber,
                     WarrantyPeriod = projectSiteAsset.WarrantyPeriod,
                     WarrantyStartDate = projectSiteAsset.WarrantyStartDate,
                     AssetId = projectSiteAsset.AssetId,
                     AssetName = projectSiteAsset.Asset.AssetName,
                     SupplierId = projectSiteAsset.SupplierId,
                     SupplierName= projectSiteAsset.Supplier.SupplierName,
                     ProjectSiteId=projectSiteAsset.ProjectSiteId,
                     clients = _context.SiteClients.Where(c=>c.ProjectSites.SiteId==SiteId && c.ProjectSites.ProjectId== ProjectId).Select(cln=> new Client {Id=cln.Id,ClientName=cln.Client.ClientName }).ToList()
                 }).ToList();
            return LstProjectSiteAsset;
        }
        public IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetByProjectId(int ProjectId)
        {
            var LstProjectSiteAsset = _context.ProjectSiteAsset.Where(ps => ps.ProjectSites.ProjectId == ProjectId)
                 .Include(ps => ps.ProjectSites.Sites).Include(ps => ps.ProjectSites).Include(ps => ps.Asset).Include(ps => ps.Supplier).Select(projectSiteAsset => new ProjectSiteAssetDTO
                 {
                     SiteId= projectSiteAsset.ProjectSites.SiteId,
                     Sitename= projectSiteAsset.ProjectSites.Sites.Sitename,
                     Days = projectSiteAsset.Days,
                     SerialNumber = projectSiteAsset.SerialNumber,
                     WarrantyPeriod = projectSiteAsset.WarrantyPeriod,
                     WarrantyStartDate = projectSiteAsset.WarrantyStartDate,
                     AssetId = projectSiteAsset.AssetId,
                     AssetName = projectSiteAsset.Asset.AssetName,
                     SupplierId = projectSiteAsset.SupplierId,
                     SupplierName = projectSiteAsset.Supplier.SupplierName,
                 }).ToList();
            return LstProjectSiteAsset;
        }
        public IEnumerable<ProjectSiteAssetDTO> GetAllAssetsSerialsByAssetId(int AssetId)
        {
            var LstProjectSiteAsset = _context.ProjectSiteAsset.Where(ps => ps.AssetId == AssetId)
                 .Select(projectSiteAsset => new ProjectSiteAssetDTO
                 {
                     Id=projectSiteAsset.Id,
                     Days = projectSiteAsset.Days,
                     SerialNumber = projectSiteAsset.SerialNumber,
                     WarrantyPeriod = projectSiteAsset.WarrantyPeriod,
                     WarrantyStartDate = projectSiteAsset.WarrantyStartDate,
                 }).ToList();
            return LstProjectSiteAsset;
        }
        public void Delete(int id)
        {
            ProjectSiteAsset projectSiteAsset = _context.ProjectSiteAsset.Where(p => p.Id == id).FirstOrDefault();
            if (projectSiteAsset != null)
            {
                _context.ProjectSiteAsset.Remove(projectSiteAsset);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public IEnumerable<ProjectSiteAssetDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectSiteAssetDTO GetById(int id)
        {
            var LstProjectSiteAsset = _context.ProjectSiteAsset.Where(ps => ps.Id == id).Include(p=>p.Asset).Include(p=>p.Supplier)
                .Select(projectSiteAsset => new ProjectSiteAssetDTO
                {
                    Id = projectSiteAsset.Id,
                    Days = projectSiteAsset.Days,
                    SerialNumber = projectSiteAsset.SerialNumber,
                    WarrantyPeriod = projectSiteAsset.WarrantyPeriod,
                    WarrantyStartDate = projectSiteAsset.WarrantyStartDate,
                    AssetId= projectSiteAsset.AssetId,
                    AssetName=projectSiteAsset.Asset.AssetName,
                    SupplierId=projectSiteAsset.SupplierId,
                    SupplierName=projectSiteAsset.Supplier.SupplierName,
                    ProjectSiteId=projectSiteAsset.ProjectSiteId,
                }).FirstOrDefault();

            if (LstProjectSiteAsset == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return LstProjectSiteAsset;
            }
        }
        public ProjectSiteAssetDTO GetProjectSiteAssetBySerialNumber(string SerialNumber)
        {
            var LstProjectSiteAsset = _context.ProjectSiteAsset.Where(ps => ps.SerialNumber == SerialNumber)
                .Select(projectSiteAsset => new ProjectSiteAssetDTO
                {
                    Id = projectSiteAsset.Id,
                    Days = projectSiteAsset.Days,
                    SerialNumber = projectSiteAsset.SerialNumber,
                    WarrantyPeriod = projectSiteAsset.WarrantyPeriod,
                    WarrantyStartDate = projectSiteAsset.WarrantyStartDate,
                    AssetId = projectSiteAsset.AssetId,
                    SupplierId = projectSiteAsset.SupplierId,
                    ProjectSiteId = projectSiteAsset.ProjectSiteId,
                }).FirstOrDefault();

            if (LstProjectSiteAsset == null)
            {
                return null;
              //  throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return LstProjectSiteAsset;
            }
        }
        public void Update(int Id, ProjectSiteAssetDTO ProjectSiteAssetDTO)
        {
            if (Id != ProjectSiteAssetDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                ProjectSiteAsset projectSiteAsset = new ProjectSiteAsset();
                projectSiteAsset.Id = ProjectSiteAssetDTO.Id;   
                projectSiteAsset.Days = ProjectSiteAssetDTO.Days;
                projectSiteAsset.SerialNumber = ProjectSiteAssetDTO.SerialNumber;
                projectSiteAsset.WarrantyPeriod = ProjectSiteAssetDTO.WarrantyPeriod;
                projectSiteAsset.WarrantyStartDate = ProjectSiteAssetDTO.WarrantyStartDate;
                projectSiteAsset.AssetId = ProjectSiteAssetDTO.AssetId;
                projectSiteAsset.SupplierId = ProjectSiteAssetDTO.SupplierId;
                projectSiteAsset.ProjectSiteId = ProjectSiteAssetDTO.ProjectSiteId;
                _context.Entry(projectSiteAsset).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
