using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interfaces;

namespace Royal_Games.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        private readonly Royal_GamesContext _context;

        public PlataformaRepository(Royal_GamesContext context)
        {
            _context = context;
        }

        public List<Plataforma> Listar()
        {
            return _context.Plataforma.ToList();
        }

        public Plataforma ObterPorId(int id)
        {
            return _context.Plataforma.FirstOrDefault(p => p.PlataformaID == id);
        }

        public bool NomeExistente(string nome, int? plataformaIdAtual = null)
        {
            var consulta = _context.Plataforma.AsQueryable();

            if (plataformaIdAtual.HasValue)
            {
                consulta = consulta.Where(p => p.PlataformaID != plataformaIdAtual.Value);
            }

            return consulta.Any(p => p.Nome == nome);
        }

        public void Adicionar(Plataforma plataforma)
        {
            _context.Plataforma.Add(plataforma);
            _context.SaveChanges();
        }

        public void Atualizar(Plataforma plataforma)
        {
            Plataforma plataformaBanco = _context.Plataforma.FirstOrDefault(p => p.PlataformaID == plataforma.PlataformaID);

            if (plataformaBanco == null)
            {
                return;
            }

            plataformaBanco.Nome = plataforma.Nome;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Plataforma plataformaBanco = _context.Plataforma.FirstOrDefault(p => p.PlataformaID == id);

            if (plataformaBanco == null)
            {
                return;
            }

            _context.Plataforma.Remove(plataformaBanco);
            _context.SaveChanges();
        }
    }
}
