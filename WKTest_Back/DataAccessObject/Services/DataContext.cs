using Microsoft.EntityFrameworkCore;
using WKTest.Common;
using WKTest.DataAccessObject.Repositories;
using WKTest.Models;

namespace WKTest.DataAccessObject.Services
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly IConfig _config;

        public DataContext(IConfig config)
        {
            _config = config;
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseMySQL(_config.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
