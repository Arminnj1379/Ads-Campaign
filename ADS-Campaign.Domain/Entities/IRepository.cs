namespace ADS_Campaign.Domain.Entities
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(dynamic id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(dynamic id);
    }
}
