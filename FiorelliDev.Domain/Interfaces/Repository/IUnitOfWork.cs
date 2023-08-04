namespace FiorelliDev.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        Task Rollback();

    }
}
