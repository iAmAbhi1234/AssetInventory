using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Commands.CompleteAssignment
{
    public class CompleteAssignmentCommandHandler : IRequestHandler<CompleteAssignmentCommand,Unit>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public CompleteAssignmentCommandHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<Unit> Handle(CompleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            // ✅ Load assignment
            var assignment = await _assignmentRepository.GetByIdAsync(request.AssignmentId);
            if (assignment == null)
                throw new NotFoundException(nameof(Assignment), request.AssignmentId);

            // ✅ Complete the assignment
            assignment.CompleteAssignment();

            // ✅ Save changes
            await _assignmentRepository.UpdateAsync(assignment);

            return Unit.Value; // MediatR convention for void
        }
    }
}
