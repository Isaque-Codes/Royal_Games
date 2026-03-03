using Royal_Games.Domains;

namespace Royal_Games.Interfaces
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
