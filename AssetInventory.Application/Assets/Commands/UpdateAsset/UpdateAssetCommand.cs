using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Commands.UpdateAsset
{
    public record UpdateAssetCommand(
        int Id,
        string? Name = null,
        string? Category = null,
        string? SerialNumber = null,
        DateTime? PurchaseDate = null,
        decimal? PurchaseCost = null,
        string? Location = null
    ) : IRequest<int>;
}
