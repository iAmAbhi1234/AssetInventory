using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Application.Maintenance.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Queries.GetMaintenanceHistoryByAsset
{
    public class GetMaintenanceHistoryByAssetQueryHandler : IRequestHandler<GetMaintenanceHistoryByAssetQuery, List<MaintenanceDto>>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public GetMaintenanceHistoryByAssetQueryHandler(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<List<MaintenanceDto>> Handle(GetMaintenanceHistoryByAssetQuery request, CancellationToken cancellationToken)
        {
            var maintenances = await _maintenanceRepository.GetAllAsync();

            var history = maintenances
                .Where(m => m.AssetId == request.AssetId)
                .OrderByDescending(m => m.ScheduledDate)
                .ToList();

            return history.Select(m => new MaintenanceDto
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
