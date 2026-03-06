namespace Royal_Games.DTOs.ClassIndicativaDto
{
    public class LerClassIndicativaDto
    {
        public int CategoriaID { get; set; }

        public string Nome { get; set; } = null!;
        public int ClassIndicativaID { get; internal set; }
    }
}
