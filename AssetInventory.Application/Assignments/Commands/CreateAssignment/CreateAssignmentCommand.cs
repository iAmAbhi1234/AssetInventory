using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Commands.CreateAssignment
{
    public record CreateAssignmentCommand(int AssetId, int EmployeeId) : IRequest<int>;
}
