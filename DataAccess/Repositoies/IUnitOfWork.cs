namespace DataAccess.Repositoies
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
