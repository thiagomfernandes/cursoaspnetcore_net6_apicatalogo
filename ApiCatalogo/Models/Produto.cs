using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models;

public class Produto
{
    public int ProdutoId { get; set; }
    [Required]
    [StringLength(200)]
    public string? Nome { get; set; }
    
    [Required]
    [StringLength(500)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName="decimal(10,2)")]
    public decimal Preco { get; set; }
    [Required]
    [StringLength(500)]
    public string? ImagemUrl { get; set; }

    [JsonIgnore]
    public float Estoque { get; set; }

    [JsonIgnore]
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }
    
    [JsonIgnore]
    public Categoria? Categoria{ get; set;}

}
