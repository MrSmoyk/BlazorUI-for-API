namespace UI.Domain.DTOs.PeriodDTOs
{
    public class DayMonthDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public void AddDay()
        {
            StartDate = StartDate.AddDays(1);
        }

        public void RemoveDay()
        {
            StartDate = StartDate.AddDays(-1);
        }

        public void AddMonth()
        {
            StartDate = StartDate.AddMonths(1);
            EndDate = EndDate.AddMonths(1);
        }
        public void RemoveMonth()
        {
            StartDate = StartDate.AddMonths(-1);
            EndDate = EndDate.AddMonths(-1);
        }
    }
}
