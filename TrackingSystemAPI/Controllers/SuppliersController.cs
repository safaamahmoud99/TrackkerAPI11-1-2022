using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private ISuppliersService _suppliersService;

        public SuppliersController(ISuppliersService suppliersService) 
        {
            _suppliersService = suppliersService;
        }
        // GET: api/<SuppliersController>
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return _suppliersService.GetAllSuppliers();
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public Supplier Get(int id)
        {
            return _suppliersService.GetSupplierById(id);
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public void Post(Supplier supplier)
        {
            _suppliersService.AddSupplier(supplier);
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, Supplier supplier)
        {
            _suppliersService.UpdateSupplier(id, supplier);

        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _suppliersService.DeleteSupplier(id);

        }
    }
}
