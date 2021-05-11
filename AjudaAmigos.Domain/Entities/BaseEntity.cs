using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaAmigos.Domain.Entities
{
    // Colocar aqui todos as propriedades que se repetem entre as classes
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
