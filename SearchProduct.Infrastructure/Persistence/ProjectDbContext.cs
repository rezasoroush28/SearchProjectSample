using Microsoft.EntityFrameworkCore;
using SearchProject.Domain.Entities;

namespace SearchProduct.Infrastructure.Persistence
{
    public class ProjectDbContext : DbContext
    {
        DbSet<Product>  products;
        DbSet<Category> categories;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
