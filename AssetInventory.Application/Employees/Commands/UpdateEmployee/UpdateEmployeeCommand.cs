using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Employees.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Department,
    string Phone = ""
) : IRequest<Unit>;
}
