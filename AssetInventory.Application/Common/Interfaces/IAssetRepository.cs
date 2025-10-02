using AssetInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Common.Interfaces
{
    public interface IAssetRepository
    {
        Task AddAsync(Asset asset);
        Task<Asset?> GetByIdAsync(int id);
        Task<IEnumerable<Asset>> GetAllAsync();
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(Asset asset);
    }
}
