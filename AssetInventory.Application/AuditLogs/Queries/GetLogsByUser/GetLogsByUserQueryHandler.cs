using AssetInventory.Application.AuditLogs.DTOs;
using AssetInventory.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.AuditLogs.Queries.GetLogsByUser
{
    public class GetLogsByUserQueryHandler : IRequestHandler<GetLogsByUserQuery, List<AuditLogDto>>
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public GetLogsByUserQueryHandler(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<List<AuditLogDto>> Handle(GetLogsByUserQuery request, CancellationToken cancellationToken)
        {
            var logs = await _auditLogRepository.GetByUserAsync(request.PerformedBy);

            return logs.Select(log => new AuditLogDto
            {
                Id = log.Id,
                Action = log.Action,
                EntityName = log.EntityName,
                EntityId = log.EntityId,
                PerformedBy = log.PerformedBy,
                PerformedAt = log.PerformedAt,
                OldValues = log.OldValues,
                NewValues = log.NewValues
            }).ToList();
        }
    }
}
