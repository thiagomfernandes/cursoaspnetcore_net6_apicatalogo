using ApiCatalogo.Context;
using ApiCatalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoUnitTests
{
    public class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        {

        }

        public void insert(ApiCatalogoDbContext context)
        {
            context.Categorias.Add(new Categoria { CategoriaId = 100, Nome = "TestBebidas", ImagemUrl = "testbebidas.jpg"});
            context.Categorias.Add(new Categoria { CategoriaId = 101, Nome = "TestSalgados", ImagemUrl = "testsalgados.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 102, Nome = "TestPizzas", ImagemUrl = "testpizzas.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 103, Nome = "TestDoces", ImagemUrl = "testdoces.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 104, Nome = "TestVerduras", ImagemUrl = "testverduras.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 105, Nome = "TestRoupas", ImagemUrl = "testroupas.jpg" });
        }

        public void cleardb(ApiCatalogoDbContext context)
        {
            context.Categorias.RemoveRange(context.Categorias.Where(c => c.CategoriaId >= 100 && c.CategoriaId <= 105));
        }
    }
}
