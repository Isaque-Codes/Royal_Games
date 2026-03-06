using Royal_Games.Domains;

namespace Royal_Games.Interfaces
{
    public interface IPlataformaRepository
    {
        List<Plataforma> Listar();
        Plataforma ObterPorId(int id);

        bool NomeExiste(string nome, int? categoriaIdAtual = null, int plataformaIdAtual = 0);

        void Adicionar(Plataforma plataforma);
        void Atualizar(Plataforma plataforma);
        void Remover(int id);
    }
}
