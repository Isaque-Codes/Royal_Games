namespace api.DTOs.LerLogJogoDto
{
    public class LerLogJogoDto
    {
        public int LogID { get; set; }

        public DateTime DataAlteracao { get; set; }

        public string? NomeAnterior { get; set; }

        public decimal? PrecoAnterior { get; set; }

        public int? JogoID { get; set; }
    }
}
