using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using System.Linq.Expressions;

namespace ControleMinutas.Interfaces.Repositories;

public interface IReadRepository<T> where T : EntidadeBase
{
    Task<Result<T>> ObterTodosAsync(params Expression<Func<T, object>>[] includes);
    Task<Result<T>> ObterPorIdAsync(int id, params Expression<Func<T, object>>[] includes);
    Task<Result<T>> ObterPorCondicaoAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<PagedResult<T>> ObterPaginadoAsync(int pagina, int tamanhoPagina, params Expression<Func<T, object>>[] includes);
}
