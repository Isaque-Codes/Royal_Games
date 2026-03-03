using System;
using System.Collections.Generic;

namespace Royal_Games.Domains;

public partial class Jogo
{
    public int JogoID { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public string Descricao { get; set; } = null!;

    public byte[] Imagem { get; set; } = null!;

    public bool? StatusJogo { get; set; }

    public int? UsuarioID { get; set; }

    public int? Class_IndicativaID { get; set; }

    public virtual ClassIndicativa? Class_Indicativa { get; set; }

    public virtual ICollection<LogAlteracaoJogo> Log_AlteracaoJogo { get; set; } = new List<LogAlteracaoJogo>();

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Genero> Genero { get; set; } = new List<Genero>();

    public virtual ICollection<Plataforma> Plataforma { get; set; } = new List<Plataforma>();
}
