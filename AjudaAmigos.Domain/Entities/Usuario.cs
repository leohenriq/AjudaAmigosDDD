using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaAmigos.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
        public string Tipo { get; set; }
    }
}
