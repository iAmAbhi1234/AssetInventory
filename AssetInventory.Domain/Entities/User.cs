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
    public class User : BaseEntity
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }

        // Private constructor for EF Core
        private User() { }

        // Domain constructor
        public User(string username, string passwordHash, UserRole role = UserRole.Viewer)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new DomainException("Username is required");

            if (passwordHash.Length < 8)
                throw new DomainException("Password hash is invalid");

            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }

        // Domain methods
        public void ChangePassword(string newPasswordHash)
        {
            if (newPasswordHash.Length < 8)
                throw new DomainException("Invalid password hash");

            PasswordHash = newPasswordHash;
            AddDomainEvent(new UserPasswordChangedEvent(Id));
        }

        public void PromoteToAdmin()
        {
            if (Role == UserRole.Admin)
                throw new DomainException("User is already an admin");

            Role = UserRole.Admin;
            AddDomainEvent(new UserRoleChangedEvent(Id, UserRole.Admin));
        }
    }
}
