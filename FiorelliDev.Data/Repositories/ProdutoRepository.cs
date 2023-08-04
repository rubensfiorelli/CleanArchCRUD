using FiorelliDev.Data.DatabaseContext;
using FiorelliDev.Domain.Entities;
using FiorelliDev.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiorelliDev.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly ApplicationDbContext _ProdutoContext;

        public ProdutoRepository(ApplicationDbContext produtoContext)
        {
            _ProdutoContext = produtoContext;
        }


        public async Task<bool> CommitAsync()
        {
            try
            {
                return await _ProdutoContext.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> CreateAsync(Produto produto)
        {
            try
            {
                produto.CreateAt = DateTime.Now;

                _ProdutoContext.Produtos.Add(produto);

                await _ProdutoContext.Produtos.FirstOrDefaultAsync(c => c.Id.Equals(produto.Id));

                var cat = produto.CreateAt;

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var seek = await _ProdutoContext.Produtos.FirstOrDefaultAsync(c => c.Id.Equals(id));
                if (seek != null)
                    return true;

                _ProdutoContext.Remove(seek);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }

        public async Task<Produto> GetAsync(Guid id)
        {
            try
            {
                return await _ProdutoContext.Produtos.FirstOrDefaultAsync(c => c.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> GetProdutoCategoriasAsync(Guid id)
        {
            try
            {
                return await _ProdutoContext.Produtos.Include(p => p.Categoria)
                                     .FirstOrDefaultAsync(c => c.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Produto>> ListAllAsync()
        {
            try
            {

                return await _ProdutoContext.Produtos.AsNoTracking()
                    .Take(20)
                    .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }

        public async Task<Produto> UpdateAsync(Produto produto)
        {
            try
            {
                var seek = await _ProdutoContext.Produtos.SingleOrDefaultAsync(e => e.Id.Equals(produto.Id));
                if (seek != null)

                    produto.UpdateAt = DateTime.UtcNow;
                produto.CreateAt = seek.CreateAt;

                _ProdutoContext.Entry(seek).CurrentValues.SetValues(seek);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return produto;
        }
    }
}
