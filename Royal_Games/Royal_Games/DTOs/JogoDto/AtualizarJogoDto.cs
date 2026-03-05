namespace Royal_Games.DTOs.JogoDto
{
    public class AtualizarJogoDto
    {
        public string Nome { get; set; } = null!;

        public decimal Preco { get; set; }

        public string Descricao { get; set; } = null!;

        public IFormFile Imagem { get; set; } = null!;

        public bool? StatusJogo { get; set; }

        public int? Class_IndicativaID { get; set; }

        public List<int> GeneroIds { get; set; } = new();

        public List<int> PlataformaIds { get; set; } = new();
    }
}
