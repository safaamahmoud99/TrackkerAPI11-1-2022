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
    public class RequestDescriptionRepository : IRequestDescriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestDescriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestDescriptionDTO requestDescriptionDTO)
        {
            try
            {
                if (requestDescriptionDTO != null)
                {
                    RequestDescription requestDescription = new RequestDescription();
                    requestDescription.Description = requestDescriptionDTO.Description;
                    requestDescription.DescriptionDate = DateTime.Now; //requestDescriptionDTO.DescriptionDate;
                    requestDescription.RequestId = requestDescriptionDTO.RequestId;
                    requestDescription.UserId = requestDescriptionDTO.UserId;
                    _context.RequestDescriptions.Add(requestDescription);
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
            RequestDescription requestDescription = _context.RequestDescriptions.Find(id);
            if (requestDescription != null)
            {
                _context.RequestDescriptions.Remove(requestDescription);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public RequestDescription Find(int id)
        {
            return _context.RequestDescriptions.Find(id);
        }

        public IEnumerable<RequestDescriptionDTO> GetAll()
        {
            var requestDescription = _context.RequestDescriptions.Include(r => r.Request).Include(r => r.User).Select(desc => new RequestDescriptionDTO
            {
                Id = desc.Id,
                Description = desc.Description,
                DescriptionDate = desc.DescriptionDate,
                RequestId = desc.RequestId,
                RequestName = desc.Request.RequestName,
                UserId = desc.UserId,
                UserName = desc.User.UserName
            }).ToList();
            return requestDescription;
        }

        public RequestDescriptionDTO GetById(int id)
        {
            var desc = _context.RequestDescriptions.Include(r => r.Request).Include(r => r.User).Where(r => r.Id == id).FirstOrDefault();
            if (desc == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var requestDescription = new RequestDescriptionDTO
                {
                    Id = desc.Id,
                    Description = desc.Description,
                    DescriptionDate = desc.DescriptionDate,
                    RequestId = desc.RequestId,
                    RequestName = desc.Request.RequestName,
                    UserId = desc.UserId,
                    UserName = desc.User.UserName
                };
                return requestDescription;
            }

        }
        public IEnumerable<RequestDescriptionDTO> GetAllDescriptionsByRequestId(int RequestId)
        {
            //List<RequestDescriptionDTO> lstRequestDescription = new List<RequestDescriptionDTO>();
            //var desc = _context.requests.Where(r => r.Id == RequestId).Select(desc => new RequestDescriptionDTO
            //{
            //    RequestId = RequestId,
            //    RequestName = desc.RequestName,
            //    DescriptionDate = desc.RequestDate,
            //    Description = desc.Description
            //    //UserId = desc.UserId,
            //    //UserName = desc.User.UserName
            //}).FirstOrDefault();

            var DescriptionsByRequest = _context.RequestDescriptions.Where(r => r.RequestId == RequestId)
                .Select(desc => new RequestDescriptionDTO
                {
                    Id = desc.Id,
                    RequestId = desc.RequestId,
                    RequestName = desc.Request.RequestName,
                    DescriptionDate = desc.DescriptionDate,
                    Description = desc.Description,
                    UserId = desc.UserId,
                    UserName = desc.User.UserName
                }).OrderByDescending(d => d.Id).ToList();
            //lstRequestDescription.Add(desc);
            //RequestDescriptionDTO requestDescription = new RequestDescriptionDTO();
            //foreach (var item in DescriptionsByRequest)
            //{
            //    lstRequestDescription.Add(item);
            //}
            return DescriptionsByRequest;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, RequestDescriptionDTO requestDescriptionDTO)
        {
            if (id != requestDescriptionDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                RequestDescription requestDescription = new RequestDescription();
                requestDescription.Description = requestDescriptionDTO.Description;
                requestDescription.DescriptionDate = requestDescriptionDTO.DescriptionDate;
                requestDescription.RequestId = requestDescriptionDTO.RequestId;
                requestDescription.UserId = requestDescriptionDTO.UserId;
                _context.Entry(requestDescription).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
