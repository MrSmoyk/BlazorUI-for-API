namespace UI.Service.Interfaces
{
    public interface IBaseService<DTO, CreateUpdateDTO>
    {
        public Task<List<DTO>> GetAllAsync();
        public Task UpdateAsync(Guid id, CreateUpdateDTO entity);
        public Task CreateAsync(List<CreateUpdateDTO> entitys);
        public Task DeleteAsync(Guid id);
        public Task DeleteAllAsync();
    }
}
