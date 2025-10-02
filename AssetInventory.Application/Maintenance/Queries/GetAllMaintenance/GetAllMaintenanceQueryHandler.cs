using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Application.Maintenance.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Queries.GetAllMaintenance
{
    public class GetAllMaintenanceQueryHandler : IRequestHandler<GetAllMaintenanceQuery, List<MaintenanceDto>>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public GetAllMaintenanceQueryHandler(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<List<MaintenanceDto>> Handle(GetAllMaintenanceQuery request, CancellationToken cancellationToken)
        {
            var maintenances = await _maintenanceRepository.GetAllAsync();

            return maintenances.Select(m => new MaintenanceDto
            {
                Id = m.Id,
                AssetId = m.AssetId,
                ScheduledDate = m.ScheduledDate,
                CompletedDate = m.CompletedDate,
                Description = m.Description,
                Cost = m.Cost,
                Status = m.Status.ToString()
            }).ToList();
        }
    }
}
