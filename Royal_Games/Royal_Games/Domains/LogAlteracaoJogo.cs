using System;
using System;
using System.Collections.Generic;

namespace Royal_Games.Domains
{
    public class LogAlteracaoJogo
    {
        public int Log_AlteracaoJogoID { get; set; }

        public DateTime DataAlteracao { get; set; }

        public string? NomeAnterior { get; set; }

        public decimal? PrecoAnterior { get; set; }

        public int? JogoID { get; set; }

        public virtual Jogo? Jogo { get; set; }
        public int LogAlteracaoJogoID { get; set; }
    }
}