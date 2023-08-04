using FiorelliDev.Data.DatabaseContext;
using FiorelliDev.Domain.Entities;
using FiorelliDev.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiorelliDev.Data.Repositories
{
    public class CategoriaRepository : ICategoriaReository
    {
        protected readonly ApplicationDbContext _categoriaContext;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoriaContext = context;
        }


        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            try
            {
                categoria.CreateAt = DateTime.Now;

                _categoriaContext.Categorias.Add(categoria);
                await _categoriaContext.Categorias.FirstOrDefaultAsync(c => c.Id.Equals(categoria.Id));

                var cat = categoria.CreateAt;

                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            try
            {
                var seek = await _categoriaContext.Categorias.SingleOrDefaultAsync(e => e.Id.Equals(categoria.Id));
                if (seek != null)

                    categoria.UpdateAt = DateTime.UtcNow;
                categoria.CreateAt = seek.CreateAt;

                _categoriaContext.Entry(seek).CurrentValues.SetValues(seek);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return categoria;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var seek = await _categoriaContext.Categorias.FirstOrDefaultAsync(c => c.Id.Equals(id));
                if (seek != null)
                    return true;

                _categoriaContext.Remove(seek);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }

        public async Task<Categoria> GetAsync(Guid id)
        {
            try
            {
                return await _categoriaContext.Categorias.FirstOrDefaultAsync(c => c.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Categoria>> ListAllAsync(Categoria categoria)
        {
            try
            {

                return await _categoriaContext.Categorias.AsNoTracking()
                    .Take(20)
                    .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {

                return await _categoriaContext.SaveChangesAsync() > 0;

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


    }
}
