namespace ControleMinutas.Entities;

public class Minuta : EntidadeBase
{
    public int TrabalhoId { get; private set; }
    public Trabalho? Trabalho { get; private set; }
    public Status Status { get; private set; }
    public DateTime Data { get; private set; }
    public decimal Valor { get; private set; }
    public decimal ValorTotal { get; private set; }

    protected Minuta() { }

    private Minuta(Trabalho trabalho, DateTime data, Status status, decimal valor, decimal valorTotal)
    {
        Trabalho = trabalho;
        Data = data;
        Status = status;
        Valor = valor;
        ValorTotal = valorTotal;
    }

    public static Minuta CriarMinuta(Trabalho trabalho, DateTime data, Status status)
    {
        var valor = CalcularValorMinuta(trabalho, status);
        var valorTotal = valor;
        return new Minuta(trabalho, data, status, valor, valorTotal);
    }

    private static decimal CalcularValorMinuta(Trabalho trabalho, Status status)
    {
        if (trabalho == null || trabalho.Valor <= 0)
        {
            throw new InvalidOperationException("O trabalho não está definido ou o valor do trabalho é inválido.");
        }
        decimal valorMinuta = trabalho.Valor;
        switch (status)
        {
            case Status.Trocada:
                if (trabalho.Entrega != null && trabalho.Empresa != null && trabalho.Empresa.TaxaTroca > 0) // Exemplo de condição
                {
                    valorMinuta *= trabalho.Empresa.TaxaTroca;
                }
                break;
            case Status.Abastecimento:
                if (trabalho.Empresa != null && trabalho.Empresa.TaxaAbastecimento > 0)
                {
                    valorMinuta *= trabalho.Empresa.TaxaAbastecimento;
                }
                break;
            default:
                valorMinuta = trabalho.Valor;
                break;
        }
        return valorMinuta;
    }
}

public enum Status
{
    Entregue,
    Trocada,
    Abastecimento,
    Perdida
}
