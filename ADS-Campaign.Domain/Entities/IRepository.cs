namespace ADS_Campaign.Domain.Entities
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(dynamic id, CancellationToken cancellationToken = default);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(dynamic id);
    }
}
