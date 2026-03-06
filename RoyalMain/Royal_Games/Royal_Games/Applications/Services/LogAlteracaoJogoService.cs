using Royal_Games.Domains;
using Royal_Games.DTOs.LogJogoDto;
using Royal_Games.Interfaces;
using static Royal_Games.Interfaces.ILogAlteracaoJogoRepository;

namespace Royal_Games.Applications.Services
{
    public class LogAlteracaoJogoService
    {
        private readonly Interfaces.ILogAlteracaoJogoRepository _repository;

        public LogAlteracaoJogoService(Interfaces.ILogAlteracaoJogoRepository repository)
        {

            _repository = repository;
        }

        public List<LerLogJogoDto> Listar()
        {
            List<LogAlteracaoJogo> logs = _repository.Listar();

            List<LerLogJogoDto> listaLogJogo = logs.Select(log => new LerLogJogoDto
            {
                LogID = log.LogAlteracaoJogoID,
                JogoID = log.JogoID,
                NomeAnterior = log.NomeAnterior,
                PrecoAnterior = log.PrecoAnterior,
                DataAlteracao = log.DataAlteracao
            }).ToList();

            return listaLogJogo;
        }

        public List<LerLogJogoDto> ListarPorJogo(int produtoId)
        {
            List<LogAlteracaoJogo> logs = _repository.ListarPorJogo(produtoId);

            List<LerLogJogoDto> listaLogProduto = logs.Select(log => new LerLogJogoDto
            {
                LogID = log.LogAlteracaoJogoID,
                JogoID = log.JogoID,
                NomeAnterior = log.NomeAnterior,
                PrecoAnterior = log.PrecoAnterior,
                DataAlteracao = log.DataAlteracao
            }).ToList();

            return listaLogProduto;
        }
    }
}
