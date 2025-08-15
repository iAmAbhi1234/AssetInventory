using AssetInventory.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Domain.Entities
{
    public class AuditLog : BaseEntity
    {
        public string Action { get; private set; }
        public string EntityName { get; private set; }
        public int EntityId { get; private set; }
        public string PerformedBy { get; private set; }
        public DateTime PerformedAt { get; private set; }
        public string? OldValues { get; private set; }
        public string? NewValues { get; private set; }

        // Private constructor for EF Core
        private AuditLog() { }

        // Domain constructor
        public AuditLog(
            string action,
            string entityName,
            int entityId,
            string performedBy,
            string? oldValues = null,
            string? newValues = null)
        {
            if (string.IsNullOrWhiteSpace(action))
                throw new DomainException("Action is required");

            Action = action;
            EntityName = entityName;
            EntityId = entityId;
            PerformedBy = performedBy;
            PerformedAt = DateTime.UtcNow;
            OldValues = oldValues;
            NewValues = newValues;
        }
    }
}
