using ControleMinutas.DTOs;
using ControleMinutas.Entities;

namespace ControleMinutas.Interfaces.Repositories;

public interface IWriteRepository<T> where T : EntidadeBase
{
    Task<Result<T>> AddAsync(T entity);
    Task<Result<T>> UpdateAsync(T entity);
    Task<Result<T>> DeleteAsync(int id);
}
