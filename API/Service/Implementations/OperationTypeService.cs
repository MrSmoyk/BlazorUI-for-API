using AutoMapper;
using DAL.Interfases;
using Domain.DTO.TypeDTOs;
using Domain.Entitys;
using Domain.Exceptions;
using Service.Interfaces;

namespace Service.Implementations
{
    public class OperationTypeService : BaseService<OperationType, OperationTypeDTO>, IOperationTypeService
    {
        private IOperationTypeRepository _operationTypeRepository;

        public OperationTypeService(IOperationTypeRepository operationTypeRepository, IMapper mapper)
            : base(operationTypeRepository, mapper)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<OperationTypeDTO> CreateOperationTypeAsync(OperationTypeCreateUpdateDTO operationTypeDTO)
        {
            if (operationTypeDTO is null)
                throw new SourceEntityNullException("Entity to set wasn't given.");

            if (operationTypeDTO.Name is null)
                throw new SourceEntityNullException("Entity to set wasn't given.");

            await CheckForUniqueName(operationTypeDTO.Name);

            var operationType = mapper.Map<OperationType>(operationTypeDTO);
            var createdOperationType = await _operationTypeRepository.CreateAsync(operationType);
            return mapper.Map<OperationTypeDTO>(createdOperationType);
        }

        public async Task<OperationTypeDTO> UpdateOperationTypeAsync(Guid id, OperationTypeCreateUpdateDTO operationTypeDTO)
        {
            if (!await _operationTypeRepository.ExistsAsync(id))
                throw new UnknownOperationTypeException($"Operation type with id {id} doesn't exsist");

            var operationType = mapper.Map<OperationType>(operationTypeDTO);
            operationType.Id = id;

            var updatedOperationType = await _operationTypeRepository.UpdateAsync(operationType);
            return mapper.Map<OperationTypeDTO>(updatedOperationType);
        }

        private async Task CheckForUniqueName(string operationTypeName)
        {
            var operationType = await _operationTypeRepository.GetTypeByNameAsync(operationTypeName);
            if (operationType is not null)
            {
                throw new AddingExistingEntityException($"Operation type with name {operationTypeName} already exists.");
            }
        }
    }
}
