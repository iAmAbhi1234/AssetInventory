using AssetInventory.Application.Assets.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Queries.GetAssetById
{
    public record GetAssetByIdQuery(int Id) : IRequest<AssetDto>;
}
