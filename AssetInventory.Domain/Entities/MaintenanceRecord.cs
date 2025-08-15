using AssetInventory.Domain.Enums;
using AssetInventory.Domain.Events;
using AssetInventory.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Entities
{
    public class MaintenanceRecord : BaseEntity
    {
        public int AssetId { get; private set; }
        public Asset Asset { get; private set; } = null!; // Required navigation

        public DateTime ScheduledDate { get; private set; }
        public DateTime? CompletedDate { get; private set; }
        public string Description { get; private set; } 
        public decimal? Cost { get; private set; }
        public MaintenanceStatus Status { get; private set; } = MaintenanceStatus.Scheduled;

        // Private constructor for EF Core
        private MaintenanceRecord() { }

        // Domain constructor
        public MaintenanceRecord(
            Asset asset,
            DateTime scheduledDate,
            string description)
        {
            Asset = asset ?? throw new DomainException("Asset is required");

            if (scheduledDate < DateTime.UtcNow.AddHours(1))
                throw new DomainException("Maintenance must be scheduled at least 1 hour in advance");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description is required");

            ScheduledDate = scheduledDate;
            Description = description;
        }

        // Domain methods
        public void CompleteMaintenance(decimal cost)
        {
            if (Status == MaintenanceStatus.Completed)
                throw new DomainException("Maintenance already completed");

            Status = MaintenanceStatus.Completed;
            CompletedDate = DateTime.UtcNow;
            Cost = cost;

            AddDomainEvent(new MaintenanceCompletedEvent(Id, AssetId, cost));
        }

        public void CancelMaintenance()
        {
            if (Status == MaintenanceStatus.Cancelled)
                throw new DomainException("Maintenance already cancelled");

            Status = MaintenanceStatus.Cancelled;
            AddDomainEvent(new MaintenanceCancelledEvent(Id, AssetId));
        }

    }
}
