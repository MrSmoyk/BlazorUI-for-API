﻿using Domain.Entitys;

namespace DAL.Interfases
{
    public interface IOperationRepository : IBaseRepository<Operation>
    {
        Task DeleteAllAsync();
        Task<IEnumerable<Operation>> GetForDateAsync(DateTime date);
        Task<IEnumerable<Operation>> GetForPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
