using Royal_Games.Domains;
using Royal_Games.DTOs.JogoDto;

namespace Royal_Games.Applications.Conversoes
{
    public class JogoParaDto
    {
        public static LerJogoDto ConverterParaDto(Jogo jogo)

        {
            return new LerJogoDto
            {
                JogoID = jogo.JogoID,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Descricao = jogo.Descricao,
                Imagem = jogo.Imagem,
                StatusJogo = jogo.StatusJogo,
                Class_IndicativaID = jogo.Class_IndicativaID,

                GeneroIds = jogo.Genero.Select(g => g.GeneroID).ToList(),
                Generos = jogo.Genero.Select(g => g.Nome).ToList(),

                PlataformaIds = jogo.Plataforma.Select(p => p.PlataformaID).ToList(),
                Plataformas = jogo.Plataforma.Select(P => P.Nome).ToList()
            };
        }
    }
}
