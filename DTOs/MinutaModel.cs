using ControleMinutas.Entities;
using System.ComponentModel.DataAnnotations;

namespace ControleMinutas.DTOs;

public class MinutaModel
{
    [Required]
    public int TrabalhoId { get; set; }
    [Required]
    public decimal Valor { get; set; }
}
