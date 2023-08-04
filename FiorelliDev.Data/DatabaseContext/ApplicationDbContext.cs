using FiorelliDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiorelliDev.Data.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
