using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Commands.CompleteMaintenance
{
    public record CompleteMaintenanceCommand(
        int MaintenanceId,
        decimal Cost
    ) : IRequest<Unit>;
}
