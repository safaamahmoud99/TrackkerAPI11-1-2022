using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _context;
        public AssetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(AssetDTO assetDTO)
        {
            try
            {
                if (assetDTO != null)
                {
                    string Ass = "Ass";
                    string AssCode = "";
                    var lstIds = _context.assets.ToList();
                    if (lstIds.Count > 0)
                    {
                        int code = lstIds.LastOrDefault().Id;
                        AssCode = Ass + (code + 1);
                    }
                    else
                    {
                        AssCode = Ass + 1;
                    }
                    Asset asset = new Asset();
                    asset.AssetName = assetDTO.AssetName;
                    asset.AssetCode = AssCode;
                    asset.AssetModel = assetDTO.AssetModel;
                    asset.BrandId = assetDTO.BrandId;
                    asset.OriginId = assetDTO.OriginId;
                    _context.assets.Add(asset);
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

        public void Delete(int id)
        {
            Asset asset = _context.assets.Find(id);
            if (asset != null)
            {
                _context.assets.Remove(asset);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            } 
        }
        public AssetDTO Find(int id)
        {
            return null;//_context.assets.Find(id);
        }

        public IEnumerable<AssetDTO> GetAll()
        {
            return _context.assets.Select(asset => new AssetDTO
            {
                Id=asset.Id,
                AssetName = asset.AssetName,
                AssetCode = asset.AssetCode,
                AssetModel = asset.AssetModel,
                BrandId = asset.BrandId,
                BrandName=asset.Brand.BrandName,
                OriginId = asset.OriginId,
                OriginName=asset.Origin.OriginName
            }).ToList();
        }

        public AssetDTO GetById(int id)
        {
            Asset asset = _context.assets.Include(a=>a.Brand).Include(b=>b.Origin).Where(a => a.Id == id).FirstOrDefault();
            if (asset == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var assetDTO = new AssetDTO
                {
                    Id = asset.Id,
                    AssetName = asset.AssetName,
                    AssetCode = asset.AssetCode,
                    AssetModel = asset.AssetModel,
                    BrandId = asset.BrandId,
                    BrandName = asset.Brand.BrandName,
                    OriginId = asset.OriginId,
                    OriginName = asset.Origin.OriginName
                };

                return assetDTO;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, AssetDTO assetDTO)
        {
            if (id != assetDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            
            try
            {
                Asset asset = new Asset();
                asset.Id = assetDTO.Id;
                asset.AssetName = assetDTO.AssetName;
                asset.AssetCode = assetDTO.AssetCode;
                asset.AssetModel = assetDTO.AssetModel;
                asset.BrandId = assetDTO.BrandId;
                asset.OriginId = assetDTO.OriginId;
                _context.Entry(asset).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }

    }
}
