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
    public class RequestImageRepositories : IRequestImageRepositories
    {
        private readonly ApplicationDbContext _context;
        public RequestImageRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(List<RequestImageDTO> requestImageDTOs)
        {
            try
            {
                if (requestImageDTOs != null)
                {
                    foreach (var item in requestImageDTOs)
                    {
                        requestImages requestImages = new requestImages();
                        requestImages.Id = item.Id;
                        requestImages.requestId = item.requestId;
                        requestImages.imageName = item.imageName;
                        _context.Add(requestImages);
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
        IEnumerable<requestImages> IRequestImageRepositories.GetAll()
        {
            return _context.RequestImages.ToList();

        }
        public void Save()
        {
            _context.SaveChanges();

        }

        public requestImages GetById(int id)
        {
            var requestImage = _context.RequestImages.Where(a => a.Id == id).FirstOrDefault();
            if (requestImage == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return requestImage;
            }

        }

        public requestImages Find(int id)
        {
            return _context.RequestImages.Find(id);

        }

        public IEnumerable<RequestImageDTO> GetRequestImageByRequestId(int requestID)
        {
            var requestImage = _context.RequestImages.Where(d => d.requestId == requestID).Select(requestImage =>
                new RequestImageDTO()
                {
                    Id = requestImage.Id,
                    imageName = requestImage.imageName,
                    requestId = requestImage.requestId
                }).OrderByDescending(d => d.Id).ToList();
            if (requestImage == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return requestImage;
            }
        }
    }
}
