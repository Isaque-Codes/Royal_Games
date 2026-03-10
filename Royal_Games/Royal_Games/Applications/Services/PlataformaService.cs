using Royal_Games.Domains;
using Royal_Games.DTOs.PlataformaDto;
using Royal_Games.Exceptions;
using Royal_Games.Interfaces;

namespace Royal_Games.Applications.Services
{
    public class PlataformaService
    {
        private readonly IPlataformaRepository _repository;

        public PlataformaService(IPlataformaRepository repository)
        {
            _repository = repository;
        }

        public List<LerPlataformaDto> Listar()
        {
            List<Plataforma> plataformas = _repository.Listar();

            List<LerPlataformaDto> plataformaDto = plataformas.Select(p => new LerPlataformaDto
            {
                PlataformaID = p.PlataformaID,
                Nome = p.Nome
            }).ToList();

            return plataformaDto;
        }

        public LerPlataformaDto ObterPorId(int id)
        {
            Plataforma plataforma = _repository.ObterPorId(id);

            if (plataforma == null)
            {
                throw new DomainException("Informe o ID correto.");
            }

            LerPlataformaDto plataformaDto = new LerPlataformaDto
            {
                PlataformaID = plataforma.PlataformaID,
                Nome = plataforma.Nome
            };

            return plataformaDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("O nome do gênero é obrigatório.");
            }
        }

        public void Adicionar(CriarPlataformaDto criarDto)
        {
            ValidarNome(criarDto.Nome);

            if (_repository.NomeExistente(criarDto.Nome))
            {
                throw new DomainException("Plataforma já existente.");
            }

            Plataforma plataforma = new Plataforma
            {
                Nome = criarDto.Nome
            };

            _repository.Adicionar(plataforma);
        }

        public void Atualizar(int id, CriarPlataformaDto atualizarDto)
        {
            ValidarNome(atualizarDto.Nome);

            Plataforma plataformaBanco = _repository.ObterPorId(id);

            if (plataformaBanco == null)
            {
                throw new DomainException("Não existe plataforma com este ID.");
            }

            if (_repository.NomeExistente(atualizarDto.Nome, plataformaIdAtual: id))
            {
                throw new DomainException("Plataforma já existente.");
            }

            plataformaBanco.Nome = atualizarDto.Nome;
            _repository.Atualizar(plataformaBanco);
        }

        public void Remover(int id)
        {
            Plataforma plataforma = _repository.ObterPorId(id);

            if (plataforma == null)
            {
                throw new DomainException("Não existe plataforma com este ID.");
            }

            _repository.Remover(id);
        }
    }
}