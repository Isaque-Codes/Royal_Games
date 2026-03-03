using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interfaces;

namespace Royal_Games.Repositories
{
    public class UsuarioRepository
    {
        private readonly Royal_GamesContext _context;

        public UsuarioRepository(Royal_GamesContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public Usuario? ObterPorId(int id)
        {
            // find performa melhor com chave primária
            return _context.Usuario.Find(id);
        }

        public Usuario? ObterPorEmail(string email)
        {
            // FirstOrDefault -> retorna nosso usuário do banco
            return _context.Usuario.FirstOrDefault(usuario => usuario.Email == email);
        }

        public bool EmailExiste(string email)
        {
            // Any -> retorna um true ou false para validar se 
            // existe ALGUM usuário com esse e-mail
            return _context.Usuario.Any(usuario => usuario.Email == email);
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            Usuario? usuarioBanco =
                _context.Usuario.FirstOrDefault(usuarioAux => usuarioAux.UsuarioID == usuario.UsuarioID);

            if (usuarioBanco == null)
            {
                return;
            }

            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Senha = usuario.Senha;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Usuario? usuario =
                _context.Usuario.FirstOrDefault(usuarioAux => usuarioAux.UsuarioID == id);

            if (usuario == null)
            {
                return;
            }

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
