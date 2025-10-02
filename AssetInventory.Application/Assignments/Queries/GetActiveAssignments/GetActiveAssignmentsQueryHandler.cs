using AssetInventory.Application.Assignments.DTOs;
using AssetInventory.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Queries.GetActiveAssignments
{
    public class GetActiveAssignmentsQueryHandler
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetActiveAssignmentsQueryHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<List<AssignmentDto>> Handle(GetActiveAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var assignments = await _assignmentRepository.GetAllAsync();
            var active = assignments.Where(a => !a.ReturnedDate.HasValue).ToList();

            return active.Select(a => new AssignmentDto
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
