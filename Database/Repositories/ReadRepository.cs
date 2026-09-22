using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleMinutas.Database.Repositories;

public class ReadRepository(AppDbContext context) : IReadRepository
{
    public async Task<Result<T>> ObterTodosAsync<T>(params Expression<Func<T, object>>[] includes) where T : EntidadeBase
    {
        try
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            List<T> entidades = await query.ToListAsync();

            return new Result<T>
            {
                Entidades = entidades,
                Success = true,
                Erros = new List<Erro>()
            };

        }
        catch (Exception ex)
        {

            return new Result<T>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro(ex.Message, "500")
                }
            };
        }
    }

    public async Task<Result<T>> ObterPorIdAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : EntidadeBase
    {
        try
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            T? entidade = await query.FirstOrDefaultAsync(e => e.Id == id);

            if (entidade == null)
            {
                return new Result<T>
                {
                    Entidades = null,
                    Success = false,
                    Erros = new List<Erro>
                    {
                         new Erro($"Item com ID {id} não encontrado.", "404")
                    }
                };
            }

            return new Result<T>
            {
                Entidades = new List<T> { entidade },
                Success = true,
                Erros = new List<Erro>()
            };

        }
        catch (Exception ex)
        {
            return new Result<T>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro(ex.Message, "500")
                }
            };
        }
    }
}
