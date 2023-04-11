using System.ComponentModel.DataAnnotations;

namespace TRABALHOFINALDOPI.Models
{
    public class Ong
    {
        [Key]
        public int OngId { get; set; }
        [Required]
        [MaxLength(100)]

        public string? Nome_Ong { get; set; }

        public virtual ICollection<DoarOuReceber>? DoarOuRecebers { get; set; }


    }
}
