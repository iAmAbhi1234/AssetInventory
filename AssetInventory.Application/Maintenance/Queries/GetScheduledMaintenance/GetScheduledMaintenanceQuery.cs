using AssetInventory.Application.Maintenance.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Queries.GetScheduledMaintenance
{
    public record GetScheduledMaintenanceQuery() : IRequest<List<MaintenanceDto>>;
}
