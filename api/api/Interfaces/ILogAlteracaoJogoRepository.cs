using api.Domains;
using api.Domains;

namespace api.Interfaces
{
    public interface ILogAlteracaoJogoRepository
    {
        List<Log_AlteracaoJogo> Listar();

        List<Log_AlteracaoJogo> ObterPorJogo(int jogoId);
    }
}
