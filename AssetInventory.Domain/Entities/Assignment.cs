using AssetInventory.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Entities
{
    public class Assignment : BaseEntity
    {
        public int AssetId { get; private set; }
        public Asset Asset { get; private set; } 

        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public DateTime AssignedDate { get; private set; }
        public DateTime? ReturnedDate { get; private set; }

        private Assignment() { }

        public Assignment(Asset asset, Employee employee)
        {
            Asset = asset ?? throw new DomainException("Asset is required");
            Employee = employee ?? throw new DomainException("Employee is required");
            AssignedDate = DateTime.UtcNow;
        }

        public void CompleteAssignment()
        {
            if (ReturnedDate.HasValue)
                throw new DomainException("Assignment already completed");

            ReturnedDate = DateTime.UtcNow;
        }   
    }
}
