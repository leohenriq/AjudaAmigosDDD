using AjudaAmigos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaAmigos.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Adicionar(TEntity obj);

        void Atualizar(TEntity obj);

        void Deletar(int id);

        IList<TEntity> ObterTodos();

        TEntity ObterPorId(int id);
    }
}
