using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;
using System.Linq.Expressions;

namespace ControleMinutas.UseCases;

public class MinutaUseCases(
    IReadRepository<Minuta> minutaReadRepository,
    IReadRepository<Trabalho> trabalhoReadRepository,
    IWriteRepository<Minuta> writeRepository
    )
{
    public async Task<Result<Minuta>> CriarMinutaAsync(int TrabalhoId, Status status = Status.EmMaos)
    {
        Result<Trabalho> trabalhoResult = await trabalhoReadRepository.ObterPorIdAsync(TrabalhoId, t => t.Empresa!, t => t.Saida!, t => t.Entrega!);

        if (trabalhoResult.Entidades == null || trabalhoResult.Entidades.Count() <= 0)
        {
            return new Result<Minuta>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Trabalho com ID {TrabalhoId} não encontrado.", "404")
                }
            };
        }
        Trabalho trabalho = trabalhoResult.Entidades.First();

        Minuta minuta = Minuta.CriarMinuta(trabalho, DateTime.UtcNow, status);

        return await writeRepository.AddAsync(minuta);
    }

    public async Task<Result<Minuta>> AtualizarMinutaAsync(int minutaId, Status status, int trabalhoId)
    {
        Result<Minuta> minutaResult = await minutaReadRepository.ObterPorIdAsync(minutaId);
        if (minutaResult.Entidades == null || minutaResult.Entidades.Count() <= 0)
        {
            return new Result<Minuta>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Minuta com ID {minutaId} não encontrada.", "404")
                }
            };
        }
        Minuta minuta = minutaResult.Entidades.First();
        Result<Trabalho> trabalhoResult = await trabalhoReadRepository.ObterPorIdAsync(trabalhoId);
        if (trabalhoResult.Entidades == null || trabalhoResult.Entidades.Count() <= 0)
        {
            return new Result<Minuta>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Trabalho com ID {trabalhoId} não encontrado.", "404")
                }
            };
        }

        Trabalho trabalho = trabalhoResult.Entidades.First();
        minuta.AtualizarMinuta(status, trabalho);
        return await writeRepository.UpdateAsync(minuta);
    }

    public async Task<Result<Minuta>> ExcluirMinutaAsync(int minutaId)
    {
        Result<Minuta> minutaResult = await minutaReadRepository.ObterPorIdAsync(minutaId);
        if (minutaResult.Entidades == null || minutaResult.Entidades.Count() <= 0)
        {
            return new Result<Minuta>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Minuta com ID {minutaId} não encontrada.", "404")
                }
            };
        }
        return await writeRepository.DeleteAsync(minutaId);
    }

    public async Task<Result<Minuta>> ObterMinutaPorId(int minutaId)
    {
        return await minutaReadRepository.ObterPorIdAsync(minutaId, m => m.Trabalho!);

    }

    public async Task<Result<Minuta>> ObterMinutasPorCondicaoAsync(Status? status, DateTime? data, int trabalhoId = 0)
    {
        Expression<Func<Minuta, bool>> predicate = m =>
        (status == null || m.Status == status) &&
        (data == null || m.Data.Date == data.Value.Date) &&
        (trabalhoId == 0 || m.TrabalhoId == trabalhoId);

        return await minutaReadRepository.ObterPorCondicaoAsync(predicate, m => m.Trabalho!);
    }
}