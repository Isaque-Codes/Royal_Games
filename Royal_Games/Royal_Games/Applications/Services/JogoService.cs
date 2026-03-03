using Royal_Games.Applications.Conversoes;
using Royal_Games.Domains;
using Royal_Games.DTOs.JogoDto;
using Royal_Games.Exceptions;
using Royal_Games.Interfaces;
using Royal_Games.Repositories;

namespace Royal_Games.Applications.Services
{
    public class JogoService
    {
        private readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public List<LerJogoDto> Listar()
        {
            List<Jogo> jogos = _repository.Listar();

            List<LerJogoDto> jogosDto = jogos
                .Select(JogoParaDto.ConverterParaDto).ToList();

            return jogosDto;
        }

        public LerJogoDto ObterPorId(int id)
        {
            Jogo jogo = _repository.ObterPorId(id);

            if (jogo == null)
            {
                throw new DomainException("Informe o ID correto.");
            }

            return JogoParaDto.ConverterParaDto(jogo);
        }
    }
}
