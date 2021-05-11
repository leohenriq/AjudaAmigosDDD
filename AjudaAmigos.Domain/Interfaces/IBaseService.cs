using AjudaAmigos.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaAmigos.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Adicionar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Deletar(int id);

        IList<TEntity> ObterTodos();

        TEntity ObterPorId(int id);

        TEntity Atualizar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
