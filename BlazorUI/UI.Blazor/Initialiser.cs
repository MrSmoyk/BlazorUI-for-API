using UI.Domain.DTOs.OperationDTOs;
using UI.Domain.DTOs.OperationTypeDTOs;
using UI.Domain.DTOs.PeriodDTOs;
using UI.Service.Implementations;
using UI.Service.Interfaces;

namespace UI.Blazor
{

    public static class Initialiser
    {
        public static void InitialiServices(this IServiceCollection services)
        {
            services.AddScoped<IApiService<OperationTypeDTO>, ApiService<OperationTypeDTO>>();
            services.AddScoped<IApiService<OperationDTO>, ApiService<OperationDTO>>();
            services.AddScoped<IApiService<PeriodDTO>, ApiService<PeriodDTO>>();
            services.AddScoped<IBaseService<OperationDTO, OperationCreateUpdateDTO>, OperationService>();
            services.AddScoped<IBaseService<OperationTypeDTO, OperationTypeCreateUpdateDTO>, OperationTypeService>();
            services.AddScoped<IPeriodReportsService, PeriodReportsService>();
        }

    }
}
