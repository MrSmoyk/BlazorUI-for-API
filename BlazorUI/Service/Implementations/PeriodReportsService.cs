using Microsoft.Extensions.Configuration;
using UI.Domain.DTOs.PeriodDTOs;
using UI.Service.Interfaces;

namespace UI.Service.Implementations
{
    public class PeriodReportsService : IPeriodReportsService
    {
        private IApiService<PeriodDTO> apiService;
        private Uri periodUri;

        public PeriodReportsService(IApiService<PeriodDTO> _apiService, IConfiguration config)
        {
            apiService = _apiService;
            periodUri = new Uri($"{config.GetSection("ApiUrl").Value}PeriodReports/");
        }

        public async Task<PeriodDTO> GetTotalForDateAsync(DayMonthDTO date)
        {
            var startDate = date.StartDate;
            var uri = $"{periodUri}Date/?date={startDate.Month}.{startDate.Day}.{startDate.Year}";
            return await apiService.GetEntityByUriAsync(uri);
        }

        public async Task<PeriodDTO> GetTotalForPeriodAsync(DayMonthDTO period)
        {
            string startDate = $"startDate={period.StartDate.Month}.{period.StartDate.Day}.{period.StartDate.Year}";
            string endDate = $"endDate={period.EndDate.Month}.{period.EndDate.Day}.{period.EndDate.Year}";
            var uri = $"{periodUri}Period?{startDate}&{endDate}";
            return await apiService.GetEntityByUriAsync(uri);
        }
    }
}
