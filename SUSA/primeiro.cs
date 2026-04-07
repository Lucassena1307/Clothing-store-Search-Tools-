// Models/Produto.cs
using System.ComponentModel.DataAnnotations;

namespace LojaOstentacaoAPI.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        public string Cor { get; set; }
        
        public string Tamanho { get; set; }
        
        public int QuantidadeEstoque { get; set; }
        
        public decimal Preco { get; set; }
    }
}
