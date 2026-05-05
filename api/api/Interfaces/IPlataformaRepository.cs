using api.Domains;
using api.Domains;

namespace api.Interfaces
{
    public interface IPlataformaRepository
    {
        List<Plataforma> Listar();

        Plataforma ObterPorId(int id);

        bool NomeExistente(string nome, int? plataformaIdAtual = null);

        void Adicionar(Plataforma plataforma);

        void Atualizar(Plataforma plataforma);

        void Remover(int id);
    }
}
