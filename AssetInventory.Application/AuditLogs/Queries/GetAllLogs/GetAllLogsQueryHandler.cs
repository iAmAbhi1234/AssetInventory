using AssetInventory.Application.AuditLogs.DTOs;
using AssetInventory.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.AuditLogs.Queries.GetAllLogs
{
    public class GetAllLogsQueryHandler : IRequestHandler<GetAllLogsQuery, List<AuditLogDto>>
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public GetAllLogsQueryHandler(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<List<AuditLogDto>> Handle(GetAllLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _auditLogRepository.GetAllAsync();

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
