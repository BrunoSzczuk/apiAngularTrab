using System;
using System.Collections.Generic;

namespace APITrabBruno.Models
{
    public partial class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public bool? Ativo { get; set; }
    }
}
