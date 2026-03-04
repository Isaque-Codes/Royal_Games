using Royal_Games.DTOs.JogoDto;
using Royal_Games.Exceptions;

namespace Royal_Games.Applications.Regras.Jogo
{
    public class ValidarCreate
    {
        public static void Validar(CriarJogoDto jogoDto)
        {
            if (string.IsNullOrWhiteSpace(jogoDto.Nome))
            {
                throw new DomainException("O nome é obrigatório.");
            }

            if (jogoDto.Preco <= 0)
            {
                throw new DomainException("O preço deve ser superior a zero.");
            }

            if (jogoDto.Imagem == null || jogoDto.Imagem.Length == 0)
            {
                throw new DomainException("A imagem é obrigatória.");
            }

            if (jogoDto.GeneroIds == null || jogoDto.GeneroIds.Count == 0)
            {
                throw new DomainException("O jogo deve possuir ao menos um gênero.");
            }

            if (jogoDto.PlataformaIds == null || jogoDto.PlataformaIds.Count == 0)
            {
                throw new DomainException("O jogo deve possuir ao menos uma plataforma.");
            }

            if (jogoDto.Class_IndicativaID == null)
            {
                throw new DomainException("A classificação indicativa é obrigatória.");
            }
        }
    }
}
