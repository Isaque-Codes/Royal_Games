using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interfaces;

namespace Royal_Games.Repositories
{
    public class ClassIndicativaRepository : IClassIndicativaRepository
    {
        private readonly Royal_GamesContext _context;

        public ClassIndicativaRepository(Royal_GamesContext context)
        {
            _context = context;
        }

        public List<ClassIndicativa> Listar()
        {
            return _context.ClassIndicativa.ToList();
        }

        public ClassIndicativa ObterPorId(int id)
        {
            return _context.ClassIndicativa.FirstOrDefault(c => c.ClassIndicativaID == id);
        }

        public bool NomeExistente(string nome, int? classIndicativaIdAtual = null)
        {
            var consulta = _context.ClassIndicativa.AsQueryable();

            if (classIndicativaIdAtual.HasValue)
            {
                consulta = consulta.Where(c => c.ClassIndicativaID != classIndicativaIdAtual.Value);
            }
            return consulta.Any(c => c.Nome == nome);
        }

        public void Adicionar(ClassIndicativa classIndicativa)
        {
            _context.ClassIndicativa.Add(classIndicativa);
            _context.SaveChanges();
        }

        public void Atualizar(ClassIndicativa classIndicativa)
        {
            ClassIndicativa classIndicativaBanco = _context.ClassIndicativa.FirstOrDefault
                (c => c.ClassIndicativaID == classIndicativa.ClassIndicativaID);

            if (classIndicativaBanco == null)
            {
                return;
            }

            classIndicativaBanco.Nome = classIndicativa.Nome;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            ClassIndicativa classIndicativaBanco = _context.ClassIndicativa.FirstOrDefault
                (c => c.ClassIndicativaID == id);

            if (classIndicativaBanco == null)
            {
                return;
            }

            _context.ClassIndicativa.Remove(classIndicativaBanco);
            _context.SaveChanges();
        }
    }
}
