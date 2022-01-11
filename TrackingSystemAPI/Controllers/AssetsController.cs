using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker.Data.DTO;
using  Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        // GET: api/Assets
        [HttpGet]
        public IEnumerable<AssetDTO> Getassets()
        {
            return _assetService.GetAllAssets();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public ActionResult<AssetDTO> GetAsset(int id)
        {
            var asset = _assetService.GetAssetById(id);
            return asset;
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutAsset(int id, AssetDTO assetDTO)
        {
            _assetService.UpdateAsset(id, assetDTO);
            return CreatedAtAction("GetAsset", new { id = assetDTO.Id }, assetDTO);

        }

        // POST: api/Assets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Asset> PostAsset(AssetDTO assetDTO)
        {
            _assetService.AddAsset(assetDTO);
            return CreatedAtAction("GetAsset", new { id = assetDTO.Id }, assetDTO);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public ActionResult<Asset> DeleteAsset(int id)
        {
            _assetService.DeleteAsset(id);
            return Ok();
        }
    }
}
