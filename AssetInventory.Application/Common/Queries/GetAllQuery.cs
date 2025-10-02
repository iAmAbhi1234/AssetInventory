using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Common.Queries
{
    public record GetAllQuery<TEntity,TDto>() : IRequest<List<TDto>> where TEntity : BaseEntity;
}
