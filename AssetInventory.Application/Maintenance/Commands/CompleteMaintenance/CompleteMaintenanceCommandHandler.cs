using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Commands.CompleteMaintenance
{
    public class CompleteMaintenanceCommandHandler : IRequestHandler<CompleteMaintenanceCommand,Unit>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public CompleteMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<Unit> Handle(CompleteMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var maintenance = await _maintenanceRepository.GetByIdAsync(request.MaintenanceId);
            if (maintenance == null)
                throw new NotFoundException(nameof(MaintenanceRecord), request.MaintenanceId);

            maintenance.CompleteMaintenance(request.Cost);

            await _maintenanceRepository.UpdateAsync(maintenance);

            return Unit.Value;
        }
    }
}
