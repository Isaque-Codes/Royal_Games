using api.Domains;
using api.Domains;

namespace api.Interfaces
{
    public interface IGeneroRepository
    {
        List<Genero> Listar();

        Genero ObterPorId(int id);

        bool NomeExistente(string nome, int? generoIdAtual = null);

        void Adicionar(Genero genero);

        void Atualizar(Genero genero);

        void Remover(int id);
    }
}
