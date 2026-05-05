using api.Exceptions;

namespace api.Applications.Regras.Usuario
{
    public class ValidarEmail
    {
        public static void Validar(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                throw new DomainException("E-mail inválido.");
            }
        }
    }
}
