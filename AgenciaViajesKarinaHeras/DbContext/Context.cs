using AgenciaViajesKarinaHeras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AgenciaViajesKarinaHeras.DbContext
{
    public class Context : System.Data.Entity.DbContext
    {
        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Viajero> Viajero { get; set; }
      
        public Context() : base("ViajesConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}