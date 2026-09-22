using ControleMinutas.DTOs;
using ControleMinutas.Entities;

namespace ControleMinutas.Interfaces.Repositories;

public interface IReadRepository
{
    Task<Result<T>> GetAllAsync<T>() where T : EntidadeBase;
    Task<Result<T>> GetByIdAsync<T>(int id) where T : EntidadeBase;
}
