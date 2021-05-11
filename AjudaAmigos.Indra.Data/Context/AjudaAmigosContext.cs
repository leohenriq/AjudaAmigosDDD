using AjudaAmigos.Domain.Entities;
using AjudaAmigos.Indra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaAmigos.Indra.Data.Context
{
    public class AjudaAmigosContext : DbContext
    {
        public AjudaAmigosContext(DbContextOptions<AjudaAmigosContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }
    }
}
