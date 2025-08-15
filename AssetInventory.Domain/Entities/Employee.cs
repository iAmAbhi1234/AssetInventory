using AssetInventory.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; } 
        public string Email { get; private set; } 
        public string Department { get; private set; } 
        public string Phone { get; private set; } 

        public ICollection<Assignment> Assignment { get; private set; } = new List<Assignment>();

        private Employee() { }

        public Employee(string firstName, string lastName, string email, string department)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("Email is required");
            }

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
        }
    }
}
