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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return _brandService.GetAllBrands();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public ActionResult<Brand> Get(int id)
        {
            return _brandService.GetBrandById(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post(Brand brand)
        {
            _brandService.AddBrand(brand);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, Brand brand)
        {
            _brandService.UpdateBrand(id, brand);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _brandService.DeleteBrand(id);
        }
    }
}
