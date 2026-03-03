using Royal_Games.Contexts;
using Royal_Games.Domains;

namespace Royal_Games.Repositories
{
    public class ClassIndicativaRepository
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
            ClassIndicativa classIndicativa = _context.ClassIndicativa.FirstOrDefault(c => c.ClassIndicativaID == id);

            return classIndicativa;
        }

        public bool NomeExiste(string nome, int? categoriaIdAtual = null)
        {
            // AsQueryable() -> cria a consulta inicial na tabela Categoria, mas ainda não executa nada no banco.
            var consulta = _context.ClassIndicativa.AsQueryable();

            // se foi informado um ID atual,
            // significa que estamos EDITANDO uma categoria existente
            // então vamos ignorar essa própria categoria na verificação
            if (categoriaIdAtual.HasValue)
            {
                // remove da busca a categoria com esse mesmo ID
                // evita que o sistema considere o próprio registro como duplicado
                // exemplo -> SELECT * FROM Categoria WHERE CategoriaID != 5
                consulta = consulta.Where(categoria => categoria.ClassIndicativaID != categoriaIdAtual.Value);
            }

            // verifica se existe alguma categoria com o mesmo nome
            // retorna true se encontrar ou false se não existir
            return consulta.Any(c => c.Nome == nome);
        }

        public void Adicionar(ClassIndicativa categoria)
        {
            _context.ClassIndicativa.Add(categoria);
            _context.SaveChanges();
        }

        public void Atualizar(ClassIndicativa categoria)
        {
            ClassIndicativa categoriaBanco = _context.ClassIndicativa.FirstOrDefault(c => c.ClassIndicativaID == categoria.ClassIndicativaID);

            if (categoriaBanco == null)
            {
                return;
            }

            categoriaBanco.Nome = categoria.Nome;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            ClassIndicativa categoriaBanco = _context.ClassIndicativa.FirstOrDefault(c => c.ClassIndicativaID == id);

            if (categoriaBanco == null)
            {
                return;
            }

            _context.ClassIndicativa.Remove(categoriaBanco);
            _context.SaveChanges();
        }
    }
}
