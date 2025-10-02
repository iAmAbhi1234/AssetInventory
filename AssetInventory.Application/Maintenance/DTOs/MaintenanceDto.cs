using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.DTOs
{
    public class MaintenanceDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public decimal? Cost { get; set; }
        public string Status { get; set; } = string.Empty; // Pending, InProgress, Completed
    }
}
