using AjudaAmigos.Domain.Entities;
using AjudaAmigos.Domain.Interfaces;
using AjudaAmigos.Indra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjudaAmigos.Indra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AjudaAmigosContext _context;

        public BaseRepository(AjudaAmigosContext context)
        {
            _context = context;
        }

        public void Adicionar(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            _context.Set<TEntity>().Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        public IList<TEntity> ObterTodos() =>
            _context.Set<TEntity>().ToList();

        public TEntity ObterPorId(int id) =>
            _context.Set<TEntity>().Find(id);

    }
}
