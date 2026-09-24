using ControleMinutas.Entities.ValueObjects;

namespace ControleMinutas.Entities;

public class Minuta : EntidadeBase
{
    public int TrabalhoId { get; private set; }
    public Trabalho? Trabalho { get; private set; }
    public StatusMinuta Status { get; private set; }
    public DateTime Data { get; private set; }
    public TrabalhoSnapshot? DadosHistoricos { get; private set; }
    public decimal ValorTotal { get; private set; }

    protected Minuta() { }

    private Minuta(Trabalho trabalho, DateTime data, StatusMinuta status, decimal valorTrabalhoAplicado, decimal taxaAbastecimentoAplicada, decimal taxaTrocaAplicada, TrabalhoSnapshot snapshot)
    {
        Trabalho = trabalho;
        Data = data;
        Status = status;
        DadosHistoricos = snapshot;

        CalcularValorMinuta();
    }

    public static Minuta CriarMinuta(Trabalho trabalho, DateTime data, StatusMinuta status)
    {
        if (trabalho == null || trabalho.Valor <= 0)
            throw new InvalidOperationException("O Trabalho é inválido.");

        if (trabalho.Empresa == null)
            throw new InvalidOperationException("Impossível criar Minuta: A Empresa do Trabalho não foi carregada na base de dados.");

        if (trabalho.Saida == null || trabalho.Entrega == null)
            throw new InvalidOperationException("Impossível criar Minuta: O terminais de saída e entrega precisam ser carregados.");

        TrabalhoSnapshot trabalhoSnapshot = new(
            EmpresaNomeRegistrado: trabalho.Empresa.Nome,
            TerminalSaidaRegistrado: trabalho.Saida.Nome,
            TerminalEntregaRegistrado: trabalho.Entrega.Nome,
            TaxaAbastecimentoAplicada: trabalho.Empresa.TaxaAbastecimento,
            TaxaTrocaAplicada: trabalho.Empresa.TaxaTroca,
            ValorTrabalhoAplicado: trabalho.Valor
            );

        decimal taxaAbastecimentoAplicada = trabalho.Empresa?.TaxaAbastecimento ?? 0;
        decimal taxaTrocaAplicada = trabalho.Empresa?.TaxaTroca ?? 0;

        return new Minuta(trabalho, data, status, trabalho.Valor, taxaAbastecimentoAplicada, taxaTrocaAplicada, trabalhoSnapshot);
    }

    public void AtualizarMinuta(StatusMinuta novoStatus)
    {
        Status = novoStatus;
        CalcularValorMinuta();
    }

    private void CalcularValorMinuta()
    {
        if (DadosHistoricos == null)
            throw new InvalidOperationException("Impossível calcular o valor da minuta: Os dados históricos precisam ser carregados.");

        decimal valorMinuta = DadosHistoricos.ValorTrabalhoAplicado;

        switch (Status)
        {
            case StatusMinuta.Trocada:
                if (DadosHistoricos.TaxaTrocaAplicada > 0)
                    valorMinuta *= DadosHistoricos.TaxaTrocaAplicada;
                break;

            case StatusMinuta.Abastecimento:
                if (DadosHistoricos.TaxaAbastecimentoAplicada > 0)
                    valorMinuta *= DadosHistoricos.TaxaAbastecimentoAplicada;
                break;
        }

        ValorTotal = valorMinuta;
    }
}

public enum StatusMinuta
{
    EmMaos,
    Entregue,
    Trocada,
    Abastecimento,
    Perdida
}
