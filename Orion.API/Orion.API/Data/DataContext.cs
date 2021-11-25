using Microsoft.EntityFrameworkCore;
using Orion.API.Data.Entities;

namespace Orion.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /*Relación de Tablas del Proyecto*/
        public DbSet<T_Cita> t_Citas { get; set; }
        public DbSet<T_TipoDocumento> T_TipoDocumentos { get; set; }
        public DbSet<T_Usuario> T_Usuarios { get; set; }
        public DbSet<T_Genero> T_Generos { get; set; }
        public DbSet<T_EPS> t_Eps { get; set; }
        public DbSet<T_FuenteContacto> t_FuenteContactos { get; set; }
        public DbSet<T_Medico> t_Medicos { get; set; }
        public DbSet<T_TipoVinculation> t_TipoVinculations { get; set; }
        public DbSet<T_Tratamiento> t_Tratamientos { get; set; }



        /*Campos unicos de cada tabla*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<T_TipoDocumento>().HasIndex(x => x.DescripcionDocumento).IsUnique();
            modelBuilder.Entity<T_Usuario>().HasIndex(x => x.Nro_Documento).IsUnique();
            modelBuilder.Entity<T_Genero>().HasIndex(x => x.DescGenero).IsUnique();
            modelBuilder.Entity<T_EPS>().HasIndex(x => x.DescEPS).IsUnique();
            modelBuilder.Entity<T_FuenteContacto>().HasIndex(x => x.Desc_fuente_contacto).IsUnique();
            modelBuilder.Entity<T_TipoVinculation>().HasIndex(x => x.DescTipoVinculacion).IsUnique();
            modelBuilder.Entity<T_Tratamiento>().HasIndex(x => x.Desc_Tratamiento).IsUnique();
            modelBuilder.Entity<T_Medico>().HasIndex(x => x.NombreMedico).IsUnique();


        }
    }
}
