using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // TODO: Implement the Unit of Work
        public Task<bool> Commit()
        {
            // Save the entity in the database...

            throw new System.NotImplementedException();
        }
    }
}
