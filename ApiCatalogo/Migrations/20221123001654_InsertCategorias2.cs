using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class InsertCategorias2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categorias (Nome, ImagemUrl) values ('Bebidas','bebidas.jpg')");
            migrationBuilder.Sql("insert into Categorias (Nome, ImagemUrl) values ('Lanches','lanches.jpg')");
            migrationBuilder.Sql("insert into Categorias (Nome, ImagemUrl) values ('Sobremesas','sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Categorias");
        }
    }
}
