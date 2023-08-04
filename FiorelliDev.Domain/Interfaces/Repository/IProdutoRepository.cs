using FiorelliDev.Domain.Entities;

namespace FiorelliDev.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IUnitOfWork
    {
        Task<Produto> CreateAsync(Produto produto);
        Task<Produto> UpdateAsync(Produto produto);
        Task<bool> DeleteAsync(Guid id);
        Task<Produto> GetAsync(Guid id);
        Task<Produto> GetProdutoCategoriasAsync(Guid id);
        Task<IList<Produto>> ListAllAsync();
    }
}
