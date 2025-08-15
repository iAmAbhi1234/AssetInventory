using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Events
{
    public sealed class MaintenanceCompletedEvent : IDomainEvent
    {
        public int MaintenanceId { get; }
        public int AssetId { get; }
        public decimal Cost { get; }
        public DateTime OccurredOn { get; }

        public MaintenanceCompletedEvent(int maintenanceId, int assetId, decimal cost)
        {
            MaintenanceId = maintenanceId;
            AssetId = assetId;
            Cost = cost;
        }
    }
}
