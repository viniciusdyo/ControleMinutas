namespace ControleMinutas.Entities;

public abstract class EntidadeBase
{
    public int Id { get; init; }
    public DateTime CriadoEm { get; set; }
    public DateTime EditadoEm { get; private set; }
}
