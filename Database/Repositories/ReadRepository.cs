using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleMinutas.Database.Repositories;

public class ReadRepository<T>(AppDbContext context) : IReadRepository<T> where T : EntidadeBase
{
    public async Task<Result<T>> ObterTodosAsync(params Expression<Func<T, object>>[] includes)
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

    public async Task<Result<T>> ObterPorIdAsync(int id, params Expression<Func<T, object>>[] includes)
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

    public async Task<Result<T>> ObterPorCondicaoAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
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

            List<T> entidades = await query.Where(predicate).ToListAsync();

            if (!entidades.Any())
            {

                return new Result<T>
                {
                    Entidades = null,
                    Success = false,
                    Erros = new List<Erro>
                    {
                        new Erro($"Nenhum item encontrado para os filtros especificados.", "404")
                    }
                };
            }

            return new Result<T>
            {
                Entidades = entidades,
                Success = true,
                Erros = new List<Erro>()
            };
        }
        catch (Exception)
        {

            return new Result<T>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Ocorreu um erro ao tentar obter os itens.", "500")
                }
            };
        }
    }
}
