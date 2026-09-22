using ControleMinutas.DTOs;
using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;
using System.Linq.Expressions;

namespace ControleMinutas.UseCases;

public class TrabalhoUseCases(
    IReadRepository<Trabalho> trabalhoReadRepository,
    IWriteRepository<Trabalho> trabalhoWriteRepository,
    IReadRepository<Empresa> empresaReadRepository,
    IReadRepository<Terminal> terminalReadRepository
    )
{
    public async Task<Result<Trabalho>> CriarTrabalhoAsync(int empresaId, int terminalSaidaId, int terminalEntregaId, decimal valor)
    {
        Result<Empresa> empresaResult = await empresaReadRepository.ObterPorIdAsync(empresaId);
        if (empresaResult.Entidades == null || empresaResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Empresa com ID {empresaId} não encontrada.", "404")
                }
            };
        }

        Empresa empresa = empresaResult.Entidades.First();

        Result<Terminal> terminalSaidaResult = await terminalReadRepository.ObterPorIdAsync(terminalSaidaId);
        if (terminalSaidaResult.Entidades == null || terminalSaidaResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Terminal de saída com ID {terminalSaidaId} não encontrado.", "404")
                }
            };
        }

        Terminal terminalSaida = terminalSaidaResult.Entidades.First();
        Result<Terminal> terminalEntregaResult = await terminalReadRepository.ObterPorIdAsync(terminalEntregaId);

        if (terminalEntregaResult.Entidades == null || terminalEntregaResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Terminal de entrega com ID {terminalEntregaId} não encontrado.", "404")
                }
            };
        }

        Terminal terminalEntrega = terminalEntregaResult.Entidades.First();
        Trabalho trabalho = Trabalho.CriarTrabalho(empresa, terminalSaida, terminalEntrega, valor);
        return await trabalhoWriteRepository.AddAsync(trabalho);
    }

    public async Task<Result<Trabalho>> AtualizarTrabalhoAsync(int trabalhoId, int empresaId, int terminalSaidaId, int terminalEntregaId, decimal valor)
    {
        Result<Trabalho> trabalhoResult = await trabalhoReadRepository.ObterPorIdAsync(trabalhoId);
        if (trabalhoResult.Entidades == null || trabalhoResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
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
        Result<Empresa> empresaResult = await empresaReadRepository.ObterPorIdAsync(empresaId);
        if (empresaResult.Entidades == null || empresaResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Empresa com ID {empresaId} não encontrada.", "404")
                }
            };
        }
        Empresa empresa = empresaResult.Entidades.First();
        Result<Terminal> terminalSaidaResult = await terminalReadRepository.ObterPorIdAsync(terminalSaidaId);
        if (terminalSaidaResult.Entidades == null || terminalSaidaResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Terminal de saída com ID {terminalSaidaId} não encontrado.", "404")
                }
            };
        }
        Terminal terminalSaida = terminalSaidaResult.Entidades.First();
        Result<Terminal> terminalEntregaResult = await terminalReadRepository.ObterPorIdAsync(terminalEntregaId);
        if (terminalEntregaResult.Entidades == null || terminalEntregaResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Terminal de entrega com ID {terminalEntregaId} não encontrado.", "404")
                }
            };
        }

        return await trabalhoWriteRepository.UpdateAsync(trabalho);
    }


    public async Task<Result<Trabalho>> ExcluirTrabalhoAsync(int trabalhoId)
    {
        Result<Trabalho> trabalhoResult = await trabalhoReadRepository.ObterPorIdAsync(trabalhoId);
        if (trabalhoResult.Entidades == null || trabalhoResult.Entidades.Count() <= 0)
        {
            return new Result<Trabalho>
            {
                Entidades = null,
                Success = false,
                Erros = new List<Erro>
                {
                    new Erro($"Trabalho com ID {trabalhoId} não encontrado.", "404")
                }
            };
        }
        return await trabalhoWriteRepository.DeleteAsync(trabalhoId);
    }

    public async Task<Result<Trabalho>> ObterTrabalhoPorId(int trabalhoId)
    {
        return await trabalhoReadRepository.ObterPorIdAsync(trabalhoId, t => t.Empresa!, t => t.Saida!, t => t.Entrega!);
    }

    public async Task<Result<Trabalho>> ObterTodosTrabalhos()
    {
        return await trabalhoReadRepository.ObterTodosAsync(t => t.Empresa!, t => t.Saida!, t => t.Entrega!);
    }

    public async Task<Result<Trabalho>> ObterTrabalhosPorCondicaoAsync(decimal valor, int empresaId, int terminalSaidaId, int terminalEntregaId)
    {
        Expression<Func<Trabalho, bool>> predicate = t => 
        (valor == 0 || t.Valor == valor) &&
        (empresaId == 0 || t.EmpresaId == empresaId) &&
            (terminalSaidaId == 0 || t.SaidaId == terminalSaidaId) &&
            (terminalEntregaId == 0 || t.EntregaId == terminalEntregaId);

        return await trabalhoReadRepository.ObterPorCondicaoAsync(predicate, t => t.Empresa!, t => t.Saida!, t => t.Entrega!);
    }
}