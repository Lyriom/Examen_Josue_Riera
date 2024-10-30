using Examen_Josue_Riera.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class JRiera
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Range(18, 100)]
    public int Edad { get; set; }

    [DataType(DataType.Currency)]
    public decimal Salario { get; set; }

    [Required]
    public bool Activo { get; set; }

    [DataType(DataType.Date)]
    public DateTime FechaRegistro { get; set; }

    public Celular? Celular { get; set; }

    [ForeignKey(nameof(Celular))]
    public int IdCelular { get; set; }

}