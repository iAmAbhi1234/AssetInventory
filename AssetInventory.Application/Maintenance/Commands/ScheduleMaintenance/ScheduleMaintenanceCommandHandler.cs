using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Commands.ScheduleMaintenance
{
    public class ScheduleMaintenanceCommandHandler : IRequestHandler<ScheduleMaintenanceCommand, int>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMaintenanceRepository _maintenanceRepository;

        public ScheduleMaintenanceCommandHandler(
            IAssetRepository assetRepository,
            IMaintenanceRepository maintenanceRepository)
        {
            _assetRepository = assetRepository;
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<int> Handle(ScheduleMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var asset = await _assetRepository.GetByIdAsync(request.AssetId);
            if (asset == null)
                throw new NotFoundException(nameof(Asset), request.AssetId);

            var maintenance = new MaintenanceRecord(asset, request.ScheduledDate, request.Description);

            await _maintenanceRepository.AddAsync(maintenance);

            return maintenance.Id;
        }
    }
}
