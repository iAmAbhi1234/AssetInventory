using AssetInventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Events
{
    public sealed class UserRoleChangedEvent : IDomainEvent
    {
        public int UserId { get; }
        public UserRole NewRole { get; }

        public DateTime OccurredOn { get; }

        public UserRoleChangedEvent(int userId, UserRole newRole)
        {
            UserId = userId;
            NewRole = newRole;
        }
    }
}
