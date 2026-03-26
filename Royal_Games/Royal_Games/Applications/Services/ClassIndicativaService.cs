using Royal_Games.Domains;
using Royal_Games.DTOs.ClassIndicativaDto;
using Royal_Games.Exceptions;
using Royal_Games.Interfaces;
using System.Security.Cryptography.Xml;

namespace Royal_Games.Applications.Services
{
    public class ClassIndicativaService
    {
        private readonly IClassIndicativaRepository _repository;

        public ClassIndicativaService(IClassIndicativaRepository repository)
        {
            _repository = repository;
        }

        public List<LerClassDto> Listar()
        {
            List<ClassIndicativa> classIndicativas = _repository.Listar();

            List<LerClassDto> lerClassDto = classIndicativas.Select(c => new LerClassDto
            {
                ClassIndicativaID = c.ClassIndicativaID,
                Nome = c.Nome
            }).ToList();

            return lerClassDto;
        }

        public LerClassDto ObterPorId(int id)
        {
            ClassIndicativa classBanco = _repository.ObterPorId(id);

            if (classBanco == null)
            {
                throw new DomainException("Informe o ID correto.");
            }

            LerClassDto classDto = new LerClassDto
            {
                ClassIndicativaID = classBanco.ClassIndicativaID,
                Nome = classBanco.Nome
            };

            return classDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("O nome é obrigatório.");
            }
        }

        public void Adicionar(CriarClassDto criarDto)
        {
            ValidarNome(criarDto.Nome);

            if (_repository.NomeExistente(criarDto.Nome))
            {
                throw new DomainException("Classificação já existente.");
            }

            ClassIndicativa newClass = new ClassIndicativa
            {
                Nome = criarDto.Nome
            };

            _repository.Adicionar(newClass);
        }

        public void Atualizar(int id, CriarClassDto atualizarDto)
        {
            ValidarNome(atualizarDto.Nome);

            ClassIndicativa classBanco = _repository.ObterPorId(id);

            if (classBanco == null)
            {
                throw new DomainException("Não existe classificação com este ID.");
            }

            if (_repository.NomeExistente(atualizarDto.Nome, classIndicativaIdAtual: id))
            {
                throw new DomainException("Classificação já existente.");
            }

            classBanco.Nome = atualizarDto.Nome;
            _repository.Atualizar(classBanco);
        }

        public void Remover(int id)
        {
            ClassIndicativa classBanco = _repository.ObterPorId(id);
            if (classBanco == null)
            {
                throw new DomainException("Não existe classificação com este ID.");
            }
            _repository.Remover(id);
        }
    }
}