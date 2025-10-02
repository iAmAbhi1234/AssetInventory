using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Commands.CreateAsset
{
    public record CreateAssetCommand
    (
        string Name,
        string Category,
        string SerialNumber,
        DateTime PurchaseDate,
        decimal? PurchaseCost = null,
        string? location = null
    ) : IRequest<int>;
}
