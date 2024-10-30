using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Josue_Riera.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Range(2000, 2024)]
        public int Año { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
    }
}
