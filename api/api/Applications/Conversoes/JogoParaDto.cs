using api.Domains;
using api.DTOs.JogoDto;

namespace api.Applications.Conversoes
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
                PlataformaIds = jogo.Plataforma.Select(p => p.PlataformaID).ToList()
            };
        }
    }
}