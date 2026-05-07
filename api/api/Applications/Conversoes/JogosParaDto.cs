using api.Domains;
using api.DTOs.JogoDto;

namespace api.Applications.Conversoes
{
    public class JogosParaDto
    {
        public static LerJogosDto ConverterParaDto(Jogo jogo)
        {
            return new LerJogosDto
            {
                JogoID = jogo.JogoID,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Descricao = jogo.Descricao,
                StatusJogo = jogo.StatusJogo,
                Class_IndicativaID = jogo.Class_IndicativaID,
                // EXIBE APENAS URL da imagem para não sobrecarregar o sistema
                ImagemUrl = $"/api/Jogo/{jogo.JogoID}/imagem",

                GeneroIds = jogo.Genero.Select(g => g.GeneroID).ToList(),
                PlataformaIds = jogo.Plataforma.Select(p => p.PlataformaID).ToList()
            };
        }
    }
}