using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Department,
    string Phone = ""
    ) : IRequest<int>;
}
