using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using System.Linq.Expressions;

namespace ControleMinutas.Interfaces.Repositories;

public interface IReadRepository
{
    Task<Result<T>> ObterTodosAsync<T>(params Expression<Func<T, object>>[] includes) where T : EntidadeBase;
    Task<Result<T>> ObterPorIdAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : EntidadeBase;
}
