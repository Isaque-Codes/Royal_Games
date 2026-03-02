using System;
using System.Collections.Generic;

namespace Royal_Games.Domains;

public partial class ClassIndicativa
{
    public int ClassIndicativaID { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Jogo> Jogo { get; set; } = new List<Jogo>();
}
