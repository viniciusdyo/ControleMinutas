using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ControleMinutas.Database.Repositories;

public class ReadRepository(AppDbContext context) : IReadRepository
{
    public async Task<Result<T>> GetAllAsync<T>() where T : EntidadeBase
    {
        try
        {
            List<T> entidades = await context.Set<T>().ToListAsync<T>();

            if (!entidades.Any())
            {
                return new Result<T>
                {
                    Entidades = null,
                    Success = false,
                    Erros = new List<Erro>
                    {
                         new Erro("Nenhuma item encontrada.", "404")
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

    public async Task<Result<T>> GetByIdAsync<T>(int id) where T : EntidadeBase
    {
        try
        {
            T? entidade = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

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
