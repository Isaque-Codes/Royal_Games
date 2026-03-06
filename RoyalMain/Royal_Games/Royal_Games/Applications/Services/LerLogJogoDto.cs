
namespace Royal_Games.Applications.Services
{
    public class LerLogJogoDto
    {
        public object LogID { get; set; }
        public int? JogoID { get; set; }
        public string NomeAnterior { get; set; }
        public decimal? PrecoAnterior { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}