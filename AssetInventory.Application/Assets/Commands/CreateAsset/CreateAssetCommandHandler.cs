using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Commands.CreateAsset
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, int>
    {
        private readonly IAssetRepository _assetRepository;

        public CreateAssetCommandHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<int> Handle(CreateAssetCommand request,CancellationToken cancellationToken)
        {
            var asset = new Asset(
                request.Name,
                request.Category,
                request.SerialNumber,
                request.PurchaseDate,
                request.PurchaseCost ?? 0,
                request.location ?? "Unassigned"
            );

            await _assetRepository.AddAsync(asset);

            return asset.Id;
        }
    }
}
