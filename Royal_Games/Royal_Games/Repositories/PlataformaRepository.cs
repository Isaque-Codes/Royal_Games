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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Plataforma> Listar()
        {
            return _context.Plataforma.ToList();
        }

        public Plataforma ObterPorId(int id)
        {
            Plataforma plataforma = _context.Plataforma.FirstOrDefault(c => c.PlataformaID == id);

            return plataforma;
        }

        public bool NomeExiste(string nome, int? plataformaIdAtual = null)
        {
            // AsQueryable() -> cria a consulta inicial na tabela Categoria, mas ainda não executa nada no banco.
            var consulta = _context.Plataforma.AsQueryable();

            // se foi informado um ID atual,
            // significa que estamos EDITANDO uma categoria existente
            // então vamos ignorar essa própria categoria na verificação
            if (plataformaIdAtual.HasValue)
            {
                // remove da busca a categoria com esse mesmo ID
                // evita que o sistema considere o próprio registro como duplicado
                // exemplo -> SELECT * FROM Categoria WHERE CategoriaID != 5
                consulta = consulta.Where(plataforma => plataforma.PlataformaID != plataformaIdAtual.Value);
            }

            // verifica se existe alguma categoria com o mesmo nome
            // retorna true se encontrar ou false se não existir
            return consulta.Any(c => c.Nome == nome);
        }

        public void Adicionar(Plataforma plataforma)
        {
            _context.Plataforma.Add(plataforma);
            _context.SaveChanges();
        }

        public void Atualizar(Plataforma plataforma)
        {
            Plataforma plataformaBanco = _context.Plataforma.FirstOrDefault(c => c.PlataformaID == plataforma.PlataformaID);

            if (plataformaBanco == null)
            {
                return;
            }

            plataformaBanco.Nome = plataforma.Nome;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Plataforma plataformaBanco = _context.Plataforma.FirstOrDefault(c => c.PlataformaID == id);

            if (plataformaBanco == null)
            {
                return;
            }

            _context.Plataforma.Remove(plataformaBanco);
            _context.SaveChanges();
        }

        public bool NomeExiste(string nome, int? categoriaIdAtual = null, int plataformaIdAtual = 0)
        {
            throw new NotImplementedException();
        }
    }
}
