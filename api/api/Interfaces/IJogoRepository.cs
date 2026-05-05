using api.Domains;
using api.Domains;

namespace api.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo ObterPorId(int id);
        bool NomeExistente(string nome, int? jogoIdAtual = null);
        byte[] ObterImagem(int id);

        void Adicionar(Jogo jogo, List<int> GeneroIds, List<int> PlataformaIds);

        void Atualizar(Jogo jogo, List<int> GeneroIds, List<int> PlataformaIds);

        void Remover(int id);
    }
}
