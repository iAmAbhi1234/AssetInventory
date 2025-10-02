using AssetInventory.Application.AuditLogs.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.AuditLogs.Queries.GetLogsByUser
{
    public record GetLogsByUserQuery(
        string PerformedBy
    ) : IRequest<List<AuditLogDto>>;
}
