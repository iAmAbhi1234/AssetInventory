using AssetInventory.Application.Assets.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Queries.GetAllAssets
{
    public record GetAllAssetsQuery() : IRequest<IReadOnlyList<AssetDto>>;
}
