using ControleMinutas.DTOs;
using ControleMinutas.Entities;

namespace ControleMinutas.Interfaces.Repositories;

public interface IWriteRepository
{
    Task<Result<T>> AddAsync<T>(T entity) where T : EntidadeBase;
    Task<Result<T>> UpdateAsync<T>(T entity) where T : EntidadeBase;
    Task<Result<T>> DeleteAsync<T>(int id) where T : EntidadeBase;
}
