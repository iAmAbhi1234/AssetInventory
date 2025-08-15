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
    public class Asset : BaseEntity
    {
        public string Name { get; private set; } 
        public string Category { get; private set; } 
        public string SerialNumber { get; private set; } 
        public DateTime PurchaseDate { get; private set; }
        public string Location { get; private set; } 
        public AssetStatus Status { get; private set; } = AssetStatus.Active;

        public ICollection<Assignment> Assignments { get; private set; } = new List<Assignment>();

        public ICollection<MaintenanceRecord> MaintenanceRecords { get; private set; } = new List<MaintenanceRecord>();

        // Private constructor for EF Core
        private Asset() { }

        // Public constructor with validation
        public Asset(string name, string category, string serialNumber, DateTime purchaseDate, string location)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Asset name cannot be empty");

            if (purchaseDate > DateTime.UtcNow)
                throw new DomainException("Purchase date cannot be in the future");

            Name = name;
            Category = category;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            Location = location;
        }

        // Domain methods
        public void MarkAsRetired()
        {
            if (Status == AssetStatus.Retired)
                throw new DomainException("Asset is already retired");

            Status = AssetStatus.Retired;
            AddDomainEvent(new AssetRetiredEvent(Id));
        }

    }
}
