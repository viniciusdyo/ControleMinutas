namespace ControleMinutas.Entities;

public class Terminal : EntidadeBase
{
    public string Nome { get; private set; } = string.Empty;
    protected Terminal() { }
    
    private Terminal(string nome)
    {
        Nome = nome;
    }
    public static Terminal CriarTerminal(string terminalNome) 
    { 
        return new Terminal(terminalNome);
    }
}
