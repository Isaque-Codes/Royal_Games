using Royal_Games.Exceptions;

namespace Royal_Games.Applications.Regras.Usuario
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
