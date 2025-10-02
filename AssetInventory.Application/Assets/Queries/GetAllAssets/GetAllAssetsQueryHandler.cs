using AssetInventory.Application.Assets.DTOs;
using AssetInventory.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Queries.GetAllAssets
{
    public class GetAllAssetsQueryHandler : IRequestHandler<GetAllAssetsQuery, IReadOnlyList<AssetDto>>
    {
        private readonly IAssetRepository _assetRepository;

        public GetAllAssetsQueryHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<IReadOnlyList<AssetDto>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
        {
            var assets = await _assetRepository.GetAllAsync();

            return assets.Select(a => new AssetDto
            {
                Id = a.Id,
                Name = a.Name,
                Category = a.Category,
                SerialNumber = a.SerialNumber,
                PurchaseDate = a.PurchaseDate,
                PurchaseCost = a.PurchaseCost,
                Location = a.Location,
                Status = a.Status.ToString()
            }).ToList();
        }
    }
}
