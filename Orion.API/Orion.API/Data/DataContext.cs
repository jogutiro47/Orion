using Microsoft.EntityFrameworkCore;
using Orion.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /*Relación de Tablas del Proyecto*/
        public DbSet<T_TipoDocumento> T_TipoDocumentos { get; set; }

        /*Campos unicos de cada tabla*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<T_TipoDocumento>().HasIndex(x => x.DescripcionDocumento).IsUnique();
        }
    }
}
