using System.ComponentModel.DataAnnotations;

namespace TRABALHOFINALDOPI.Models
{
    public class DoarOuReceber
    {
        public int DoarOuReceberId { get; set; }
        [Required]
        [MaxLength(40)]

        public string? Nome { get; set; }
        [Required]
        [MaxLength(40)]

        public string? Sobrenome { get; set; }
        [MaxLength(150)]

        public string? Email { get; set; }
        [MaxLength(14)]

        public string? Celular { get; set; }

        public bool QuerDoar { get; set; }
        public bool QuerReceber { get; set; }


        public virtual Pedido? Nome_Item { get; set; }
        [Required]



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime DataPedido { get; set; }


        public int PedidoId { get; set; }
        [Required]
       
        public virtual Ong? Nome_Ong { get; set; }
        [Required]

        public int OngId { get; set; }

       

     
    }
}
