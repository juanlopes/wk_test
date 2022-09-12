using Microsoft.EntityFrameworkCore;
using WKTest.Models;

namespace WKTest.DataAccessObject.Repositories
{
    public interface IDataContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public void Commit();
    }
}
