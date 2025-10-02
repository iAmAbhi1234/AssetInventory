using AssetInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Common.Interfaces
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog auditLog); // For commands later if needed
        Task<IEnumerable<AuditLog>> GetAllAsync();
        Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityName, int entityId);
        Task<IEnumerable<AuditLog>> GetByUserAsync(string performedBy);
    }
}
