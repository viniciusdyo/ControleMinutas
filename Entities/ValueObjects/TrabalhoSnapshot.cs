namespace ControleMinutas.Entities.ValueObjects;

public record TrabalhoSnapshot(
    string EmpresaNomeRegistrado,
    string TerminalSaidaRegistrado,
    string TerminalEntregaRegistrado,
    decimal TaxaAbastecimentoAplicada,
    decimal TaxaTrocaAplicada,
    decimal ValorTrabalhoAplicado
    );
