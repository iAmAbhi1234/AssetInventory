using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Commands.RetireAsset
{
    public class RetireAssetCommandHandler : IRequestHandler<RetireAssetCommand, int>
    {
        private readonly IAssetRepository _repo;

        public RetireAssetCommandHandler(IAssetRepository repo) => _repo = repo;

        public async Task<int> Handle(RetireAssetCommand request, CancellationToken ct)
        {
            var asset = await _repo.GetByIdAsync(request.Id);
             if (asset is null) 
                throw new NotFoundException(nameof(asset), request.Id);

            asset.MarkAsRetired();

            await _repo.UpdateAsync(asset);
            return asset.Id;
        }
    }
}
