using ControleMinutas.Entities;

namespace ControleMinutas.DTOs;

public class PagedResult<T> : Result<T> where T : EntidadeBase
{
    public int TotalRegistros { get; set; }
    public int TotalPaginas { get; set; }
    public int PaginaAtual { get; set; }
    public int TamanhoPagina { get; set; }
}
