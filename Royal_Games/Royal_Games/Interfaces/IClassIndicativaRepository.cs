using Royal_Games.Domains;

namespace Royal_Games.Interfaces
{
    public interface IClassIndicativaRepository
    {
        List<ClassIndicativa> Listar();
        ClassIndicativa ObterPorId(int id);

        bool NomeExiste(string nome, int? categoriaIdAtual = null, int classIndicativaIdAtual = 0);

        void Adicionar(ClassIndicativa categoria);
        void Atualizar(ClassIndicativa categoria);
        void Remover(int id);
    }
}
