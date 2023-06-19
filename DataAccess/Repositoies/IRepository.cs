using System.Linq.Expressions;

namespace DataAccess.Repositoies
{
    public interface IRepository<T>
    {
        void SetAsNoTrackingStatus(bool status);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAll(params string[] includeProperties);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties);

        Task<T> GetFirstAsync();
        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate,
            params string[] includeProperties);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties);

        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        IQueryable<T> Table { get; }
    }
}
