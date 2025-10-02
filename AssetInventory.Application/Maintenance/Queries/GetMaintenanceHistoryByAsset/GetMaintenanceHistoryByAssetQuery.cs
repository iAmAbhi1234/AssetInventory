using AssetInventory.Application.Maintenance.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Maintenance.Queries.GetMaintenanceHistoryByAsset
{
    public record GetMaintenanceHistoryByAssetQuery(int AssetId) : IRequest<List<MaintenanceDto>>;
}
