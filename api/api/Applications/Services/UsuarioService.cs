using api.Domains;
using api.DTOs.UsuarioDto;
using api.Exceptions;
using api.Interfaces;
using api.Applications.Regras.Usuario;
using api.Domains;
using api.DTOs.UsuarioDto;
using api.Exceptions;
using api.Interfaces;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace api.Applications.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        private static LerUsuarioDto LerDto(Usuario usuario)
        {
            LerUsuarioDto lerUsuario = new LerUsuarioDto
            {
                UsuarioID = usuario.UsuarioID,
                Nome = usuario.Nome,
                Email = usuario.Email,
                StatusUsuario = usuario.StatusUsuario ?? true
            };

            return lerUsuario;
        }

        public List<LerUsuarioDto> Listar()
        {
            List<Usuario> usuarios = _repository.Listar();

            List<LerUsuarioDto> usuariosDto = usuarios
                .Select(usuarioBanco => LerDto(usuarioBanco))
                .ToList();

            return usuariosDto;
        }

        private static byte[] HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new DomainException("A senha é obrigatória.");
            }

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        public LerUsuarioDto ObterPorId(int id)
        {
            Usuario usuario = _repository.ObterPorId(id);

            if (usuario == null)
            {
                throw new DomainException("Usuário inexistente.");
            }

            return LerDto(usuario);
        }

        public LerUsuarioDto ObterPorEmail(string email)
        {
            Usuario usuario = _repository.ObterPorEmail(email);

            if (usuario == null)
            {
                throw new DomainException("Usuário não existe");
            }

            return LerDto(usuario);
        }

        public LerUsuarioDto Adicionar(CriarUsuarioDto usuarioDto)
        {
            ValidarEmail.Validar(usuarioDto.Email);

            if (_repository.EmailExistente(usuarioDto.Email))
            {
                throw new DomainException("E-mail já cadastrado.");
            }

            Usuario usuario = new Usuario
            {
                Email = usuarioDto.Email,
                Nome = usuarioDto.Nome,
                Senha = HashSenha(usuarioDto.Senha),
                StatusUsuario = true
            };

            _repository.Adicionar(usuario);
            return LerDto(usuario);
        }

        public LerUsuarioDto Atualizar(int id, CriarUsuarioDto usuarioDto)
        {
            Usuario usuarioBanco = _repository.ObterPorId(id);

            if (usuarioBanco == null)
            {
                throw new DomainException("Usuário inexistente.");
            }

            ValidarEmail.Validar(usuarioDto.Email);

            Usuario usuarioComMesmoEmail = _repository.ObterPorEmail(usuarioDto.Email);

            if (usuarioComMesmoEmail != null && usuarioComMesmoEmail.UsuarioID != id)
            {
                throw new DomainException("Já existe um usuário com este e-mail.");
            }

            usuarioBanco.Nome = usuarioDto.Nome;
            usuarioBanco.Email = usuarioDto.Email;
            usuarioBanco.Senha = HashSenha(usuarioDto.Senha);

            _repository.Atualizar(usuarioBanco);

            return LerDto(usuarioBanco);
        }

        public void Remover(int id)
        {
            Usuario usuario = _repository.ObterPorId(id);

            if (usuario == null)
            {
                throw new DomainException("Usuário inexistente.");
            }

            _repository.Remover(id);
        }
    }
}
