using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Application.Employees.Commands.CreateEmployee;
using AssetInventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Employees.Commands.UpdateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Department,
                request.Phone
            );

            await _employeeRepository.AddAsync(employee);

            return employee.Id;
        }
    }
}
