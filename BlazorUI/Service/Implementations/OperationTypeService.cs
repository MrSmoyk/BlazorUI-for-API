using Microsoft.Extensions.Configuration;
using UI.Domain.DTOs.OperationTypeDTOs;
using UI.Service.Interfaces;

namespace UI.Service.Implementations
{
    public class OperationTypeService : IBaseService<OperationTypeDTO, OperationTypeCreateUpdateDTO>
    {
        private IApiService<OperationTypeDTO> apiService;
        private Uri operationTypeUri;

        public OperationTypeService(IApiService<OperationTypeDTO> _apiService, IConfiguration config)
        {
            apiService = _apiService;
            operationTypeUri = new Uri($"{config.GetSection("ApiUrl").Value}OperationTypes/");
        }

        public async Task<List<OperationTypeDTO>> GetAllAsync()
        {
            return await apiService.GetAllByUriAsync(operationTypeUri.AbsoluteUri);
        }

        public async Task CreateAsync(List<OperationTypeCreateUpdateDTO> entitys)
        {
            await apiService.CreateAsync(entitys, operationTypeUri.AbsoluteUri);
        }

        public async Task UpdateAsync(Guid id, OperationTypeCreateUpdateDTO entity)
        {
            var uri = $"{operationTypeUri.AbsoluteUri}{id}";
            await apiService.UpdateAsync(entity, uri);
        }

        public async Task DeleteAsync(Guid id)
        {
            var uri = $"{operationTypeUri.AbsoluteUri}{id}";
            await apiService.DeleteAsync(uri);
        }

        public async Task DeleteAllAsync()
        {
            await apiService.DeleteAsync(operationTypeUri.AbsoluteUri);
        }
    }
}
