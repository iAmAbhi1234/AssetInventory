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
        public decimal PurchaseCost { get; private set; }
        public string Location { get; private set; } 
        public AssetStatus Status { get; private set; } = AssetStatus.Active;

        public ICollection<Assignment> Assignments { get; private set; } = new List<Assignment>();

        public ICollection<MaintenanceRecord> MaintenanceRecords { get; private set; } = new List<MaintenanceRecord>();

        // Private constructor for EF Core
        private Asset() { }

        // Public constructor with validation
        public Asset(string name, string category, string serialNumber, DateTime purchaseDate,decimal purchaseCost, string location)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Asset name cannot be empty");

            if (purchaseDate > DateTime.UtcNow)
                throw new DomainException("Purchase date cannot be in the future");

            if (purchaseCost < 0)
                throw new DomainException("Purchase cost can't be less than 0");

            Name = name;
            Category = category;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            PurchaseCost = purchaseCost;
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

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new DomainException("Asset name cannot be empty");

            Name = newName;
            //AddDomainEvent(new AssetUpdatedEvent(Id));
        }

        public void ChangeCategory(string newCategory)
        {
            if (string.IsNullOrWhiteSpace(newCategory))
                throw new DomainException("Category cannot be empty");

            Category = newCategory;
            //AddDomainEvent(new AssetUpdatedEvent(Id));
        }

        public void ChangeSerialNumber(string newSerialNumber)
        {
            if (string.IsNullOrWhiteSpace(newSerialNumber))
                throw new DomainException("Serial number cannot be empty");

            SerialNumber = newSerialNumber;
            //AddDomainEvent(new AssetUpdatedEvent(Id));
        }

        public void ChangePurchaseDate(DateTime newDate)
        {
            if (newDate > DateTime.UtcNow)
                throw new DomainException("Purchase date cannot be in the future");

            PurchaseDate = newDate;
            //AddDomainEvent(new AssetUpdatedEvent(Id));
        }

        public void ChangePurchaseCost(decimal newCost)
        {
            if (newCost < 0)
                throw new DomainException("Purchase cost cannot be negative");

            PurchaseCost = newCost;
            //AddDomainEvent(new AssetUpdatedEvent(Id));
        }

        public void MoveTo(string newLocation)
        {
            if (string.IsNullOrWhiteSpace(newLocation))
                throw new DomainException("Location cannot be empty");

            Location = newLocation;
            //AddDomainEvent(new AssetUpdatedEvent(Id));
        }

    }
}
