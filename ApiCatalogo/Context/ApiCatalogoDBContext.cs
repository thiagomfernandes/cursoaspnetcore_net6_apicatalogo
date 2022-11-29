using ApiCatalogo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ApiCatalogo.Context
{
    public class ApiCatalogoDbContext : IdentityDbContext
    {
        public ApiCatalogoDbContext(DbContextOptions<ApiCatalogoDbContext> options) : base(options)
        { }

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }


    }
}
