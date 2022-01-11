using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class AssetDTO
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string AssetModel { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int OriginId { get; set; }
        public string OriginName { get; set; }
    }
}
