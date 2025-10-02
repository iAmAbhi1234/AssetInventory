using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Application.Maintenance.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Queries.GetMaintenanceById
{
    public class GetMaintenanceByIdQueryHandler : IRequestHandler<GetMaintenanceByIdQuery, MaintenanceDto>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public GetMaintenanceByIdQueryHandler(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<MaintenanceDto> Handle(GetMaintenanceByIdQuery request, CancellationToken cancellationToken)
        {
            var maintenance = await _maintenanceRepository.GetByIdAsync(request.Id);
            if (maintenance == null)
                throw new NotFoundException(nameof(maintenance), request.Id);

            return new MaintenanceDto
            {
                Id = maintenance.Id,
                AssetId = maintenance.AssetId,
                ScheduledDate = maintenance.ScheduledDate,
                CompletedDate = maintenance.CompletedDate,
                Description = maintenance.Description,
                Cost = maintenance.Cost,
                Status = maintenance.Status.ToString()
            };
        }
    }
}
