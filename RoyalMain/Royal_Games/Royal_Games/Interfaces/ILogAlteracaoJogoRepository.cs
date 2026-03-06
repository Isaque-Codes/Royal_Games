using Royal_Games.Domains;

namespace Royal_Games.Interfaces
{
    public interface ILogAlteracaoJogoRepository
    {
        List<LogAlteracaoJogo> Listar();
        List<LogAlteracaoJogo> ListarPorJogo(int jogoId);

        public interface ILogAlteracaoJogoRepository
        {
            List<LogAlteracaoJogo> Listar();
            List<LogAlteracaoJogo> ListarPorJogo(int jogoId);
        }
    }
}
