using System;
using System.Collections.Generic;

namespace APITrabBruno.Models
{
    public partial class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Numerohabitantes { get; set; }
        public bool? Ativo { get; set; }
    }
}
