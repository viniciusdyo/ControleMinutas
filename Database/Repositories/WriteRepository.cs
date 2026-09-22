using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ControleMinutas.Database.Repositories;

public class WriteRepository(AppDbContext context) : IWriteRepository
{
    public async Task<Result<T>> AddAsync<T>(T entity) where T : EntidadeBase
    {
        try
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return new Result<T>
            {
                Entidades = new List<T> { entity },
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
                Erros = new List<Erro> { new Erro("Ocorreu um erro ao adicionar o item.", "500") }
            };
        }
    }

    public async Task<Result<T>> DeleteAsync<T>(int id) where T : EntidadeBase
    {
        try
        {
            await context.Set<T>().Where(x => x.Id == id).ExecuteDeleteAsync<T>();
            return new Result<T>
            {
                Entidades = null,
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
                Erros = new List<Erro> { new Erro("Ocorreu um erro ao excluir o item.", "500") }
            };        
        }
    }

    public async Task<Result<T>> UpdateAsync<T>(T entity) where T : EntidadeBase
    {
        try
        {
            await context.Set<T>().Where(x => x.Id == entity.Id).ExecuteUpdateAsync<T>(x => x.SetProperty(e => e, entity));
            await context.SaveChangesAsync();

            return new Result<T>
            {
                Entidades = new List<T> { entity },
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
                Erros = new List<Erro> { new Erro("Ocorreu um erro ao atualizar o item.", "500") }
            };
        }
    }
}
