using api.Domains;
using api.Domains;

namespace api.Interfaces
{
    public interface IClassIndicativaRepository
    {
        List<ClassIndicativa> Listar();

        ClassIndicativa ObterPorId(int id);

        bool NomeExistente(string nome, int? classIndicativaIdAtual = null);

        void Adicionar(ClassIndicativa classIndicativa);

        void Atualizar(ClassIndicativa classIndicativa);

        void Remover(int id);
    }
}
