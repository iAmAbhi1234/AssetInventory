using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Commands.ScheduleMaintenance
{
    public record ScheduleMaintenanceCommand(
        int AssetId,
        DateTime ScheduledDate,
        string Description
    ) : IRequest<int>;
}
