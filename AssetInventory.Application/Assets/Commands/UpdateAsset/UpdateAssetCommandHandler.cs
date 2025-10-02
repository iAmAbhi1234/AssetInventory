using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Commands.UpdateAsset
{
    public class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand, int>
    {
        private readonly IAssetRepository _repo;

        public UpdateAssetCommandHandler(IAssetRepository repo) => _repo = repo;

        public async Task<int> Handle(UpdateAssetCommand request, CancellationToken ct)
        {
            var asset = await _repo.GetByIdAsync(request.Id);
            if (asset is null)
                throw new NotFoundException(nameof(Asset), request.Id);

            // Apply only provided changes (null = no change)
            if (request.Name is not null) asset.Rename(request.Name);
            if (request.Category is not null) asset.ChangeCategory(request.Category);
            if (request.SerialNumber is not null) asset.ChangeSerialNumber(request.SerialNumber);
            if (request.PurchaseDate.HasValue) asset.ChangePurchaseDate(request.PurchaseDate.Value);
            if (request.PurchaseCost.HasValue) asset.ChangePurchaseCost(request.PurchaseCost.Value);
            if (request.Location is not null) asset.MoveTo(request.Location);

            await _repo.UpdateAsync(asset);
            return asset.Id;
        }
    }
}
