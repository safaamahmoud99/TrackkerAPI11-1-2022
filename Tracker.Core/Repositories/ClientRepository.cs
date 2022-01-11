using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Data.ViewModels;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ClientDTO clientDTO)
        {
            //try
            //{
                if (clientDTO != null)
                {
                    var clemailFound = _context.clients.Where(c => c.Email == clientDTO.Email && c.Id != clientDTO.Id).ToList();
                    if(clemailFound.Count>0)
                    {
                        throw new AlreadyFoundException("email already found");
                    }
                    var clcodeFound = _context.clients.Where(c => c.ClientCode == clientDTO.ClientCode && c.Id != clientDTO.Id).ToList();
                    if (clcodeFound.Count > 0)
                    {
                        throw new AlreadyFoundException("code already found");
                    }
                    var clphoneFound = _context.clients.Where(c => c.Phone == clientDTO.Phone && c.Id != clientDTO.Id).ToList();
                    if (clphoneFound.Count > 0)
                    {
                        throw new AlreadyFoundException("phone already found");
                    }
                    else
                    {
                        var client = new Client();
                        client.Address = clientDTO.Address;
                        client.ClientCode = clientDTO.ClientCode;
                        client.ClientName = clientDTO.ClientName;
                        client.Email = clientDTO.Email;
                        client.gender = clientDTO.gender;
                        client.Phone = clientDTO.Phone;
                        client.Photo = clientDTO.Photo;
                        _context.clients.Add(client);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            //}
            //catch (Exception)
            //{
            //    throw new NotExistException("Not Exist Exception");
            //}
        }

        public void Delete(int id)
        {
            Client client = _context.clients.Find(id);
            if (client != null)
            {
                _context.clients.Remove(client);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public Client Find(int id)
        {
            return _context.clients.Find(id);
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            var client = _context.clients.Select(e => new ClientDTO
            {
                Id = e.Id,
                ClientName = e.ClientName,
                Phone = e.Phone,
                //OrganizationId=e.OrganizationId,
                Address = e.Address,
                ClientCode = e.ClientCode,
                Email = e.Email,
                gender = e.gender,
                Photo = e.Photo,
                //OrganizationName=e.Organization.OrganizationName

            }).ToList();
            return client;
        }

        public ClientDTO GetById(int id)
        {
            var client = _context.clients.FirstOrDefault(e => e.Id == id);
            if (client == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var clientDTO = new ClientDTO
                {
                    Id = client.Id,
                    ClientName = client.ClientName,
                    Phone = client.Phone,
                    Address = client.Address,
                    ClientCode = client.ClientCode,
                    Email = client.Email,
                    gender = client.gender,
                    Photo = client.Photo,

                };

                return clientDTO;
            }
        }
        public void Update(int id, ClientDTO clientDTO)
        {
            if (id != clientDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            //try
            //{
            var clemailFound = _context.clients.Where(c => c.Email == clientDTO.Email && c.Id != clientDTO.Id).ToList();
            if (clemailFound.Count > 0)
            {
                throw new AlreadyFoundException("email already found");
            }
            var clcodeFound = _context.clients.Where(c => c.ClientCode == clientDTO.ClientCode && c.Id != clientDTO.Id).ToList();
            if (clcodeFound.Count > 0)
            {
                throw new AlreadyFoundException("code already found");
            }
            var clphoneFound = _context.clients.Where(c => c.Phone == clientDTO.Phone && c.Id != clientDTO.Id).ToList();
            if (clphoneFound.Count > 0)
            {
                throw new AlreadyFoundException("phone already found");
            }
            else
            {
                var client = new Client();
                client.Id = clientDTO.Id;
                client.Address = clientDTO.Address;
                client.ClientCode = clientDTO.ClientCode;
                client.ClientName = clientDTO.ClientName;
                client.Email = clientDTO.Email;
                client.gender = clientDTO.gender;
                //client.OrganizationId = clientDTO.OrganizationId;
                client.Phone = clientDTO.Phone;
                client.Photo = clientDTO.Photo;
                _context.Entry(client).State = EntityState.Modified;
                _context.SaveChanges();
            }
            //}
            //catch (Exception)
            //{
            //    throw new NotCompletedException("Not Completed Exception");
            //}
        }
    }
}
