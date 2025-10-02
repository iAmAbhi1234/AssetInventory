using AssetInventory.Application.Assignments.DTOs;
using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQueryHandler : IRequestHandler<GetAssignmentByIdQuery,AssignmentDto>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetAssignmentByIdQueryHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<AssignmentDto> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(request.AssignmentId);
            if (assignment == null)
                throw new NotFoundException(nameof(Assignment), request.AssignmentId);

            return new AssignmentDto
            {
                Id = assignment.Id,
                AssetId = assignment.AssetId,
                EmployeeId = assignment.EmployeeId,
                AssignedDate = assignment.AssignedDate,
                ReturnedDate = assignment.ReturnedDate
            };
        }
    }
}
