namespace ControleMinutas.Entities;

public class Trabalho : EntidadeBase
{
    public int EmpresaId { get; private set; }
    public Empresa? Empresa { get; private set; }
    public int SaidaId { get; private set; }
    public Terminal? Saida { get; private set; }
    public int EntregaId { get; private set; }
    public Terminal? Entrega { get; private set; }
    public decimal Valor { get; private set; }

    protected Trabalho() { }

    private Trabalho(int empresa, int saida, int entrega, decimal valor)
    {
        EmpresaId = empresa;
        SaidaId = saida;
        EntregaId = entrega;
        Valor = valor;
    }

    public static Trabalho CriarTrabalho(Empresa empresa, Terminal saida, Terminal entrega, decimal valor)
    {
        return new Trabalho(empresa.Id, saida.Id, entrega.Id, valor);
    }
}
