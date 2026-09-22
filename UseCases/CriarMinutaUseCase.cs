using ControleMinutas.Entities;
using ControleMinutas.Interfaces.Repositories;

namespace ControleMinutas.UseCases;

public class CriarMinutaUseCase(
    IReadRepository<Minuta> readRepository,
    IWriteRepository<Minuta> writeRepository
    )
{
}
