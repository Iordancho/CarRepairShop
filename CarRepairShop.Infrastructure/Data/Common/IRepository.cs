namespace CarRepairShop.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All <T>() where T : class;
        IQueryable<T> AllReadOnly<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
        Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task RemoveAsync<T>(T entity) where T : class;
    }
}
