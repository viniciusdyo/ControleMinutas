using ControleMinutas.Entities;

namespace ControleMinutas.DTOs;

public class Result<T> where T : EntidadeBase
{
    public List<T>? Entidades { get; set; }
    public List<Erro> Erros { get; set; } = new List<Erro>();
    public bool Success { get; set; }
}

public record Erro(string Mensagem, string Codigo);
