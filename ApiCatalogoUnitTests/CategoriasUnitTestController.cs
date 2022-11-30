using ApiCatalogo.Context;
using ApiCatalogo.Controllers;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoUnitTests
{
    public class CategoriasUnitTestController
    {
        private ApiCatalogoDbContext _context;
        public static DbContextOptions<ApiCatalogoDbContext> dbContextOptions { get; }

      

        static CategoriasUnitTestController()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var mysqlConnStr = config.GetConnectionString("DefaultConnection");

            dbContextOptions = new DbContextOptionsBuilder<ApiCatalogoDbContext>()
                .UseMySql(mysqlConnStr, ServerVersion.AutoDetect(mysqlConnStr))
                .Options;
        }

        public CategoriasUnitTestController()
        {
            _context = new ApiCatalogoDbContext(dbContextOptions);
        }

        [Fact]
        public async void Categorias_Get_Return_OkResult()
        {
            var controller = new CategoriasController(_context);
            var data = await controller.Get();
            Assert.IsType<List<Categoria>>(data.Value);
        }
        [Fact]
        public async void Categorias_Get_Return_BadRequestResult()
        {
            var controller = new CategoriasController(_context);
            var data = await controller.Get();
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public async void Categorias_GetById_Return_OkResult()
        {
            //Arrange
            var controller = new CategoriasController(_context);

            //Act
            var data = await controller.Get(1);

            //Assert
            Assert.IsType<Categoria>(data.Value);
        }

        [Fact]
        public async void Categorias_GetById_Return_NotFoundResult()
        {
            //Arrange
            var controller = new CategoriasController(_context);

            //Act
            var data = await controller.Get(999);

            //Assert
            Assert.IsType<NotFoundObjectResult>(data.Result);
        }

        [Fact]
        public async void Categorias_Post_ValidData_Return_CreatedResult()
        {
            //Arrange
            var controller = new CategoriasController(_context);
            var cPost = new Categoria {CategoriaId = 900, Nome = "testNew", ImagemUrl = "testnew.jpg" };

            //Act
            var data = await controller.Post(cPost);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(data);
        }
        [Fact]
        public async void Categorias_Delete_Return_OkResult()
        {
            //Arrange
            var controller = new CategoriasController(_context);
            var cId = 900;

            //Act
            var data = await controller.Delete(cId);

            //Assert
            Assert.IsType<OkObjectResult>(data.Result);
        }
    }
}
