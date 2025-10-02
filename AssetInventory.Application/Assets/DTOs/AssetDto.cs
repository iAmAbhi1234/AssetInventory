using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.DTOs
{
    public class AssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseCost { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // Available, Assigned, Retired, etc.
    }
}
