using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(200)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(500)]
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
