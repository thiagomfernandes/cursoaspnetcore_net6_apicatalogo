using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors("AllowExternalGet")]
    public class ProdutosController : ControllerBase
    {

        private readonly ApiCatalogoDbContext _context;

        public ProdutosController(ApiCatalogoDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            if (produtos is null)
                return NotFound("Nenhum produto no DB");
            return produtos;

        }

        [HttpGet("pagined")]
        public async Task<ActionResult<IEnumerable<Produto>>> Get([FromQuery] ProdutosParameters ppar)
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            var totalPages = (int)Math.Ceiling(produtos.Count / (double)ppar.PageSize);

            if (ppar.PageNumber > totalPages)
                ppar.PageNumber = totalPages;

            var paginedProdutos = produtos
                .OrderBy(p => p.ProdutoId)
                .Skip((ppar.PageNumber - 1) * ppar.PageSize)
                .Take(ppar.PageSize)
                .ToList();

            var pageData = new Dictionary<string, int>(){
                { "TotalRecords", produtos.Count},
                { "TotalPages", totalPages},
                { "CurrentPage", ppar.PageNumber }
            };

            if (produtos is null)
                return NotFound("Nenhum produto no DB");

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageData));

            return paginedProdutos;

        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == id);
            if (produto is null)
                return NotFound("Produto não encontrado");
            return produto;

        }

        [HttpPost]
        public async Task<ActionResult> Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Update(produto);
            // _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);
            if (produto is null)
                return NotFound("Produto não encontrado");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }
    }
}
