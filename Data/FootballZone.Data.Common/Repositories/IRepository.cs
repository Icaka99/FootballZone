namespace FootballZone.Data.Common.Repositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> AllAsNoTracking();

        Task AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(string id);

        Task<int> SaveChangesAsync();
    }
}
