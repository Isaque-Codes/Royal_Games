using Royal_Games.Domains;
using Royal_Games.DTOs.ClassIndicativaDto;
using Royal_Games.Exceptions;
using Royal_Games.Interfaces;

namespace Royal_Games.Applications.Services
{
    public class ClassIndicativaService
    {
        private readonly IClassIndicativaRepository _repository;

        public ClassIndicativaService(IClassIndicativaRepository repository)
        {
            _repository = repository;
        }

        public List<LerClassIndicativaDto> Listar()
        {
            List<ClassIndicativa> classIndicativa = _repository.Listar();

            // converte cada categoria para LerCategoriaDto
            List<LerClassIndicativaDto> classIndicativaDto = classIndicativa.Select(classIndicativa => new LerClassIndicativaDto
            {
                ClassIndicativaID = classIndicativa.ClassIndicativaID,
                Nome = classIndicativa.Nome
            }).ToList();

            // Retorna a lista já convertida em DTO
            return classIndicativaDto;
        }

        public LerClassIndicativaDto ObterPorId(int id)
        {
            ClassIndicativa classIndicativa = _repository.ObterPorId(id);

            if (classIndicativa == null)
            {
                throw new DomainException("Categoria não encontrada");
            }

            LerClassIndicativaDto classIndicativaDto = new LerClassIndicativaDto
            {
                ClassIndicativaID = classIndicativa.ClassIndicativaID,
                Nome = classIndicativa.Nome
            };

            return classIndicativaDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }
        }

        public void Adicionar(CriarClassIndicativaDto criarDto)
        {
            ValidarNome(criarDto.Nome);

            if (_repository.NomeExiste(criarDto.Nome))
            {
                throw new DomainException("Categoria já existente.");
            }

            ClassIndicativa classIndicativa = new ClassIndicativa
            {
                Nome = criarDto.Nome,
            };

            _repository.Adicionar(classIndicativa);
        }

        public void Atualizar(int id, CriarClassIndicativaDto criarDto)
        {
            ValidarNome(criarDto.Nome); // valida se o campo nome foi preenchido

            ClassIndicativa classIndicativaBanco = _repository.ObterPorId(id);

            if (classIndicativaBanco == null)
            {
                throw new DomainException("Categoria não encontrada.");
            }

            // categoriaIdAtual: id -> categoriaIdAtual recebe id
            if (_repository.NomeExiste(criarDto.Nome, classIndicativaIdAtual: id))
            {
                throw new DomainException("Já existe outra categoria com esse nome.");
            }

            classIndicativaBanco.Nome = criarDto.Nome;
            _repository.Atualizar(classIndicativaBanco);
        }

        public void Remover(int id)
        {
            ClassIndicativa classIndicativaBanco = _repository.ObterPorId(id);

            if (classIndicativaBanco == null)
            {
                throw new DomainException("Categoria não encontrada.");
            }

            _repository.Remover(id);
        }
    }
}
