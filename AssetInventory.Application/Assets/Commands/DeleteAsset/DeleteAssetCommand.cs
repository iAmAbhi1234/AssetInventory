using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Commands.DeleteAsset
{
    public record DeleteAssetCommand(int Id) : IRequest<int>;
}
