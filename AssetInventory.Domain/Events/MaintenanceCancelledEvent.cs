using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Events
{
    public sealed class MaintenanceCancelledEvent : IDomainEvent
    {

        public int MaintenanceId { get; }
        public int AssetId { get; }
        public DateTime OccurredOn { get; }
        public MaintenanceCancelledEvent(int maintenanceId, int assetId)
        {
            MaintenanceId = maintenanceId;
            AssetId = assetId;
        }

        
    }
}
