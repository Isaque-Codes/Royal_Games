using Microsoft.EntityFrameworkCore;
using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interfaces;

namespace Royal_Games.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly Royal_GamesContext _context;

        public JogoRepository(Royal_GamesContext context)
        {
            _context = context;
        }

        public List<Jogo> Listar()
        {
            List<Jogo> jogos = _context.Jogo
                .Include(j => j.Genero)
                .Include(j => j.Plataforma)
                .Include(j => j.Class_Indicativa)
                .ToList();

            return jogos;
        }

        public Jogo ObterPorId(int id)
        {
            Jogo jogo = _context.Jogo
                .Include(j => j.Genero)
                .Include(j => j.Plataforma)
                .Include(j => j.Class_Indicativa)
                .FirstOrDefault(J => J.JogoID == id);

            return jogo;
        }

        public bool NomeExistente(string nome, int? jogoIdAtual = null)
        {
            var jogoConsultado = _context.Jogo.AsQueryable();

            if (jogoIdAtual.HasValue)
            {
                jogoConsultado = jogoConsultado.Where(j => j.JogoID != jogoIdAtual.Value);
            }

            return jogoConsultado.Any(j => j.Nome == nome);
        }

        public byte[] ObterImagem(int id)
        {
            var jogo = _context.Jogo
                .Where(j => j.JogoID == id)
                .Select(j => j.Imagem)
                .FirstOrDefault();

            return jogo;
        }

        public void Adicionar(Jogo jogo, List<int> GeneroIds, List<int> PlataformaIds)
        {
            List<Genero> generos = _context.Genero
                .Where(g => GeneroIds
                .Contains(g.GeneroID))
                .ToList();

            jogo.Genero = generos;

            List<Plataforma> plataformas = _context.Plataforma
                .Where(p => PlataformaIds
                .Contains(p.PlataformaID))
                .ToList();

            jogo.Plataforma = plataformas;

            _context.Jogo.Add(jogo);
            _context.SaveChanges();
        }

        public void Atualizar(Jogo jogo, List<int> GeneroIds, List<int> PlataformaIds)
        {
            Jogo? jogoBanco = _context.Jogo
                .Include(j => j.Genero)
                .Include(j => j.Plataforma)
                .FirstOrDefault(j => j.JogoID == jogo.JogoID);

            if (jogoBanco == null)
            {
                return;
            }

            jogoBanco.Nome = jogo.Nome;
            jogoBanco.Preco = jogo.Preco;
            jogoBanco.Descricao = jogo.Descricao;

            if (jogo.Imagem != null && jogo.Imagem.Length > 0)
            {
                jogoBanco.Imagem = jogo.Imagem;
            }

            if (jogo.StatusJogo.HasValue)
            {
                jogoBanco.StatusJogo = jogo.StatusJogo;
            }

            var generos = _context.Genero
                .Where(generos => GeneroIds
                .Contains(generos.GeneroID))
                .ToList();

            jogoBanco.Genero.Clear();

            foreach (var genero in generos)
            {
                jogoBanco.Genero.Add(genero);
            }

            var plataformas = _context.Plataforma
                .Where(plataformas => PlataformaIds
                .Contains(plataformas.PlataformaID))
                .ToList();

            jogoBanco.Plataforma.Clear();

            foreach (var plataforma in plataformas)
            {
                jogoBanco.Plataforma.Add(plataforma);
            }

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Jogo jogo = _context.Jogo.FirstOrDefault(j => j.JogoID == id);

            if (jogo == null)
            {
                return;
            }

            _context.Jogo.Remove(jogo);
            _context.SaveChanges();
        }
    }
}