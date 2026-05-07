using api.Contexts;
using api.Domains;
using api.Interfaces;

namespace api.Repositories
{
    public class LogAlteracaoJogoRepository : ILogAlteracaoJogoRepository
    {
        private readonly Royal_GamesContext _context;

        public LogAlteracaoJogoRepository(Royal_GamesContext context)
        {
            _context = context;
        }

        public List<Log_AlteracaoJogo> Listar()
        {
            List<Log_AlteracaoJogo> logsJogos = _context.Log_AlteracaoJogo
                .OrderByDescending(l => l.DataAlteracao)
                .ToList();

            return logsJogos;
        }

        public List<Log_AlteracaoJogo> ObterPorJogo(int jogoId)
        {
            List<Log_AlteracaoJogo> logsJogo = _context.Log_AlteracaoJogo
                .Where(log => log.JogoID == jogoId)
                .OrderByDescending(log => log.DataAlteracao)
                .ToList();

            return logsJogo;
        }
    }
}
