using Royal_Games.Domains;
using Royal_Games.DTOs.GeneroDto;
using Royal_Games.Exceptions;
using Royal_Games.Interfaces;

namespace Royal_Games.Applications.Services
{
    public class GeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public List<LerGeneroDto> Listar()
        {
            List<Genero> generos = _repository.Listar();

            List<LerGeneroDto> generoDto = generos.Select(g => new LerGeneroDto
            {
                GeneroID = g.GeneroID,
                Nome = g.Nome
            }).ToList();

            return generoDto;
        }

        public LerGeneroDto ObterPorId(int id)
        {
            Genero genero = _repository.ObterPorId(id);

            if (genero == null)
            {
                throw new DomainException("Informe o ID correto.");
            }

            LerGeneroDto generoDto = new LerGeneroDto
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            };

            return generoDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("O nome do gênero é obrigatório.");
            }
        }

        public void Adicionar(CriarGeneroDto criarDto)
        {
            ValidarNome(criarDto.Nome);

            if (_repository.NomeExistente(criarDto.Nome))
            {
                throw new DomainException("Gênero já existente.");
            }

            Genero genero = new Genero
            {
                Nome = criarDto.Nome
            };

            _repository.Adicionar(genero);
        }

        public void Atualizar(int id, CriarGeneroDto atualizarDto)
        {
            ValidarNome(atualizarDto.Nome);

            Genero generoBanco = _repository.ObterPorId(id);

            if (generoBanco != null)
            {
                throw new DomainException("Não existe gênero com este ID.");
            }

            if (_repository.NomeExistente(atualizarDto.Nome, generoIdAtual: id))
            {
                throw new DomainException("Gênero já existente.");
            }

            generoBanco.Nome = atualizarDto.Nome;
            _repository.Atualizar(generoBanco);
        }

        public void Remover(int id)
        {
            Genero generoBanco = _repository.ObterPorId(id);

            if (generoBanco == null)
            {
                throw new DomainException("Não existe gênero com este ID.");
            }

            _repository.Remover(id);
        }
    }
}
