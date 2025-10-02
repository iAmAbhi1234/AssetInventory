using AssetInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Common.Interfaces
{
    public interface IMaintenanceRepository
    {
        Task AddAsync(MaintenanceRecord maintenance);
        Task<MaintenanceRecord?> GetByIdAsync(int id);
        Task<IEnumerable<MaintenanceRecord>> GetAllAsync();
        Task UpdateAsync(MaintenanceRecord maintenance);
        Task DeleteAsync(MaintenanceRecord maintenance);
    }
}
