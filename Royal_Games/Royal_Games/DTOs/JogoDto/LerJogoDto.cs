namespace Royal_Games.DTOs.JogoDto
{
    public class LerJogoDto
    {
        public int JogoID { get; set; }

        public string Nome { get; set; } = null!;

        public decimal Preco { get; set; }

        public string Descricao { get; set; } = null!;

        public byte[] Imagem { get; set; } = null!;

        public bool? StatusJogo { get; set; }

        public int? Class_IndicativaID { get; set; }

        public List<int> GeneroIds { get; set; } = new();
        public List<string> Generos { get; set; } = new();

        public List<int> PlataformaIds { get; set; } = new();
        public List<string> Plataformas { get; set; } = new();
    }
}
