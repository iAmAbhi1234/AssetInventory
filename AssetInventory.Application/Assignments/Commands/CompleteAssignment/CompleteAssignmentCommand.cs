using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Commands.CompleteAssignment
{
    public record CompleteAssignmentCommand(int AssignmentId) : IRequest<Unit>;
}
