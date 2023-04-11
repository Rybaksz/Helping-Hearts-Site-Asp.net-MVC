using System.ComponentModel.DataAnnotations;

namespace TRABALHOFINALDOPI.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [Required]
        [MaxLength(100)]



        public string? Nome_Item { get; set; }

        public virtual ICollection<DoarOuReceber>? DoarOuRecebers { get; set; }

    }
}
