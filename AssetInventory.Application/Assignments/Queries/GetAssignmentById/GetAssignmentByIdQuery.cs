using AssetInventory.Application.Assignments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Queries.GetAssignmentById
{
    public record GetAssignmentByIdQuery(int AssignmentId) : IRequest<AssignmentDto>;
}
