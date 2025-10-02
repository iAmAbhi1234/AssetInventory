using AssetInventory.Application.Employees.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Employees.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
}
