using api.Applications.Conversoes;
using api.Domains;
using api.DTOs.JogoDto;
using api.Exceptions;
using api.Interfaces;
using api.Repositories;
using System.Diagnostics.Eventing.Reader;
using api.Applications.Regras.Jogo;

namespace api.Applications.Services
{
    public class JogoService
    {
        private readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public List<LerJogosDto> Listar()
        {
            List<Jogo> jogos = _repository.Listar();

            return jogos.Select(JogosParaDto.ConverterParaDto).ToList();
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

        public byte[] ObterImagem(int id)
        {
            byte[] imagem = _repository.ObterImagem(id);

            if (imagem == null || imagem.Length == 0)
            {
                throw new DomainException("Informe o ID correto.");
            }

            return imagem;
        }

        public LerJogoDto Adicionar(CriarJogoDto jogoDto)
        {
            ValidarCreate.Validar(jogoDto);

            if (_repository.NomeExistente(jogoDto.Nome))
            {
                throw new DomainException("Já existe um jogo com este nome.");
            }

            Jogo jogo = new Jogo
            {
                Nome = jogoDto.Nome,
                Preco = jogoDto.Preco,
                Descricao = jogoDto.Descricao,
                Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem),
                Class_IndicativaID = jogoDto.Class_IndicativaID
            };

            _repository.Adicionar(jogo, jogoDto.GeneroIds, jogoDto.PlataformaIds);

            return JogoParaDto.ConverterParaDto(jogo);
        }

        public LerJogoDto Atualizar(int id, AtualizarJogoDto jogoDto)
        {
            Jogo jogoBanco = _repository.ObterPorId(id);

            if (jogoBanco == null)
            {
                throw new DomainException("Informe o ID coreto.");
            }

            if (!string.IsNullOrEmpty(jogoDto.Nome) && _repository.NomeExistente(jogoDto.Nome, jogoIdAtual: id))
            {
                throw new DomainException("Já existe um jogo com este nome.");
            }

            ValidarUpdate.Validar(jogoDto);

            jogoBanco.Nome = jogoDto.Nome ?? jogoBanco.Nome;
            jogoBanco.Preco = jogoDto.Preco ?? jogoBanco.Preco;
            jogoBanco.Descricao = jogoDto.Descricao ?? jogoBanco.Descricao;
            jogoBanco.Class_IndicativaID = jogoDto.Class_IndicativaID ?? jogoBanco.Class_IndicativaID;

            if (jogoDto.Imagem != null && jogoDto.Imagem.Length > 0)
            {
                jogoBanco.Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem);
            }

            if (jogoDto.StatusJogo.HasValue)
            {
                jogoBanco.StatusJogo = jogoDto.StatusJogo.Value;
            }

            _repository.Atualizar(jogoBanco, jogoDto.GeneroIds, jogoDto.PlataformaIds);

            return JogoParaDto.ConverterParaDto(jogoBanco);
        }

        public void Remover(int id)
        {
            Jogo jogo = _repository.ObterPorId(id);

            if (jogo == null)
            {
                throw new DomainException("Informe o ID correto.");
            }

            _repository.Remover(id);
        }
    }
}
