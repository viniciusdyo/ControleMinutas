using ControleMinutas.Entities;

namespace ControleMinutas.DTOs;

public class TrabalhoModel
{
    public int EmpresaId { get; private set; }
    public int SaidaId { get; private set; }
    public int EntregaId { get; private set; }
    public decimal Valor { get; private set; }
}
