using FiorelliDev.Domain.Entities;

namespace FiorelliDev.Domain.Interfaces.Repository
{
    public interface ICategoriaReository : IUnitOfWork
    {
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        Task<bool> DeleteAsync(Guid id);
        Task<Categoria> GetAsync(Guid id);
        Task<IList<Categoria>> ListAllAsync(Categoria categoria);
    }
}
