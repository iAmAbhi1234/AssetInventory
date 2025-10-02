using AssetInventory.Application.Common.Exceptions;
using AssetInventory.Application.Common.Interfaces;
using AssetInventory.Domain.Entities;
using AssetInventory.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInventory.Application.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand,int>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAssignmentRepository _assignmentRepository;

        public CreateAssignmentCommandHandler(
            IAssetRepository assetRepository,
            IEmployeeRepository employeeRepository,
            IAssignmentRepository assignmentRepository)
        {
            _assetRepository = assetRepository;
            _employeeRepository = employeeRepository;
            _assignmentRepository = assignmentRepository;
        }

        public async Task<int> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
        {
            // ✅ Load asset and employee
            var asset = await _assetRepository.GetByIdAsync(request.AssetId);
            if (asset == null)
                throw new NotFoundException(nameof(Asset), request.AssetId);

            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
                throw new NotFoundException(nameof(Employee), request.EmployeeId);

            // ✅ Business Rule: Asset must be available
            if (asset.Status != Domain.Enums.AssetStatus.Active)
                throw new DomainException("Asset is not available for assignment");

            // ✅ Create assignment
            var assignment = new Assignment(asset, employee);

            await _assignmentRepository.AddAsync(assignment);

            return assignment.Id;
        }

    }
}
