using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Events
{
    public sealed class UserPasswordChangedEvent : IDomainEvent
    {
        public int UserId { get; }
        public DateTime OccurredOn { get; }

        public UserPasswordChangedEvent(int userId)
        {
            UserId = userId;
        }
    }
}
