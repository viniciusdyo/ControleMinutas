namespace ControleMinutas.Entities;

public class Empresa : EntidadeBase
{
    public string Nome { get; private set; } = string.Empty;
    public decimal TaxaAbastecimento { get; private set; }
    public decimal TaxaTroca { get; private set; }

    protected Empresa() { }

    private Empresa(string nome, decimal taxaAbastecimento, decimal taxaTroca)
    {
        Nome = nome;
        TaxaAbastecimento = taxaAbastecimento;
        TaxaTroca = taxaTroca;
    }

    public static Empresa CriarEmpresa(string nome, decimal taxaAbastecimento, decimal taxaTroca)
    {
        return new Empresa(nome, taxaAbastecimento, taxaTroca);
    }
}
