using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Application.Maintenance.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Queries.GetScheduledMaintenance
{
    public class GetScheduledMaintenanceQueryHandler : IRequestHandler<GetScheduledMaintenanceQuery, List<MaintenanceDto>>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public GetScheduledMaintenanceQueryHandler(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<List<MaintenanceDto>> Handle(GetScheduledMaintenanceQuery request, CancellationToken cancellationToken)
        {
            var maintenances = await _maintenanceRepository.GetAllAsync();

            var scheduled = maintenances
                .Where(m => m.Status == Domain.Enums.MaintenanceStatus.Scheduled)
                .OrderBy(m => m.ScheduledDate)
                .ToList();

            return scheduled.Select(m => new MaintenanceDto
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
