using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

    }
}
