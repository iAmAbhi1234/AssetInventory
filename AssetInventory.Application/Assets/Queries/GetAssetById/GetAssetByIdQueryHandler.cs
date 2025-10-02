using AssetInventory.Application.Assets.DTOs;
using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Queries.GetAssetById
{
    public class GetAssetByIdQueryHandler : IRequestHandler<GetAssetByIdQuery, AssetDto>
    {
        private readonly IAssetRepository _assetRepository;

        public GetAssetByIdQueryHandler(IAssetRepository assetRepository) => _assetRepository = assetRepository;

        public async Task<AssetDto> Handle(GetAssetByIdQuery request, CancellationToken ct)
        {
            var asset = await _assetRepository.GetByIdAsync(request.Id);

            if (asset == null)
                throw new NotFoundException(nameof(Asset), request.Id);


            return new AssetDto
            {
                Id = asset.Id,
                Name = asset.Name,
                Category = asset.Category,
                SerialNumber = asset.SerialNumber,
                PurchaseDate = asset.PurchaseDate,
                PurchaseCost = asset.PurchaseCost,
                Location = asset.Location,
                Status = asset.Status.ToString()
            };
        }
    }
}
