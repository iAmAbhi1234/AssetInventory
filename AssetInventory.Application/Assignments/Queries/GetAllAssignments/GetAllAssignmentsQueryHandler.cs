using AssetInventory.Application.Assignments.DTOs;
using AssetInventory.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Queries.GetAllAssignments
{
    public class GetAllAssignmentsQueryHandler : IRequestHandler<GetAllAssignmentsQuery, List<AssignmentDto>>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetAllAssignmentsQueryHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<List<AssignmentDto>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var assignments = await _assignmentRepository.GetAllAsync();

            return assignments.Select(a => new AssignmentDto
            {
                Id = a.Id,
                AssetId = a.AssetId,
                EmployeeId = a.EmployeeId,
                AssignedDate = a.AssignedDate,
                ReturnedDate = a.ReturnedDate
            }).ToList();
        }
    }
}
