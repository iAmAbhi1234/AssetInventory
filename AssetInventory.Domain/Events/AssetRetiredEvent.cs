using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Events
{
    public sealed class AssetRetiredEvent : IDomainEvent
    {
        public int AssetId { get; set; }
        public DateTime OccurredOn { get;  }

        public AssetRetiredEvent(int assetId)
        {
            AssetId = assetId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
