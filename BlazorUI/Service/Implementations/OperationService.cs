using Microsoft.Extensions.Configuration;
using UI.Domain.DTOs.OperationDTOs;
using UI.Service.Interfaces;

namespace UI.Service.Implementations
{
    public class OperationService : IBaseService<OperationDTO, OperationCreateUpdateDTO>
    {
        private IApiService<OperationDTO> apiService;
        private Uri operationsUri;

        public OperationService(IApiService<OperationDTO> _apiService, IConfiguration config)
        {
            apiService = _apiService;
            operationsUri = new Uri($"{config.GetSection("ApiUrl").Value}Operations/");
        }

        public async Task<List<OperationDTO>> GetAllAsync()
        {
            return await apiService.GetAllByUriAsync(operationsUri.AbsoluteUri);
        }

        public async Task CreateAsync(List<OperationCreateUpdateDTO> entity)
        {
            await apiService.CreateAsync(entity, operationsUri.AbsoluteUri);
        }

        public async Task UpdateAsync(Guid id, OperationCreateUpdateDTO entity)
        {
            var uri = $"{operationsUri.AbsoluteUri}{id}";
            await apiService.UpdateAsync(entity, uri);
        }

        public async Task DeleteAsync(Guid id)
        {
            var uri = $"{operationsUri.AbsoluteUri}{id}";
            await apiService.DeleteAsync(uri);
        }

        public async Task DeleteAllAsync()
        {
            await apiService.DeleteAsync(operationsUri.AbsoluteUri);
        }
    }
}
