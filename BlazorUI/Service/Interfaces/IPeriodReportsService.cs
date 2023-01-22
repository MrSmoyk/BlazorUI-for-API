using UI.Domain.DTOs.PeriodDTOs;

namespace UI.Service.Interfaces
{
    public interface IPeriodReportsService
    {
        public Task<PeriodDTO> GetTotalForDateAsync(DayMonthDTO date);
        public Task<PeriodDTO> GetTotalForPeriodAsync(DayMonthDTO period);
    }
}
