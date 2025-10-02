using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assets.Commands.DeleteAsset
{
    public class DeleteAssetCommandHandler
    {
        private readonly IAssetRepository _repo;

        public DeleteAssetCommandHandler(IAssetRepository repo) => _repo = repo;

        public async Task<int> Handle(DeleteAssetCommand request, CancellationToken ct)
        {
            var asset = await _repo.GetByIdAsync(request.Id);
            if(asset is null)
                throw new NotFoundException(nameof(asset), request.Id);

            await _repo.DeleteAsync(asset);
            return request.Id;
        }
    }
}
