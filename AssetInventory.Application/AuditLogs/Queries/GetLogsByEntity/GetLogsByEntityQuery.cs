using AssetInventory.Application.AuditLogs.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.AuditLogs.Queries.GetLogsByEntity
{
    public record GetLogsByEntityQuery(
        string EntityName,
        int EntityId
    ) : IRequest<List<AuditLogDto>>;
}
