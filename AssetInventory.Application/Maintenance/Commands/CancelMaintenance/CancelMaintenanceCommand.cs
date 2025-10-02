using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Commands.CancelMaintenance
{
    public record CancelMaintenanceCommand(int MaintenanceId) : IRequest<Unit>;
}
