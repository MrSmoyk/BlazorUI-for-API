namespace UI.Service.Interfaces
{
    public interface IApiService<T>
    {
        public Task<List<T>> GetAllByUriAsync(string uri);
        public Task<T> GetEntityByUriAsync(string uri);
        public Task CreateAsync(IEnumerable<object> entitys, string uri);
        public Task UpdateAsync(object entity, string uri);
        public Task DeleteAsync(string uri);
    }
}
