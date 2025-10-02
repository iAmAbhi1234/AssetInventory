using AssetInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Common.Interfaces
{
    public interface IAssignmentRepository
    {
        Task AddAsync(Assignment assignment);
        Task<Assignment?> GetByIdAsync(int id);
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task UpdateAsync(Assignment assignment);
    }
}
