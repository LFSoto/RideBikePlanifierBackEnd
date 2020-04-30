using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class RideBikePlanifierContext : DbContext
    {
        public RideBikePlanifierContext(DbContextOptions<RideBikePlanifierContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioRuta>().HasKey(x => new { x.ruta, x.usuario });

            modelBuilder.Entity<UsuarioRuta>().HasOne(x => x.usuarioNavigation).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UsuarioRuta>().HasOne(x => x.rutaNavigation).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Amigo>().HasKey(x => new { x.usuario, x.amigo });

            modelBuilder.Entity<Amigo>().HasOne(x => x.usuarioNavigation).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Amigo>().HasOne(x => x.amigoNavigation).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Coordenada>().HasKey(x => new { x.ruta, x.latitud, x.longitud });

            modelBuilder.Entity<Coordenada>().HasOne(x => x.rutaNavigation).WithMany().OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Ruta> rutas { get; set; }
        public DbSet<UsuarioRuta> usuarioRutas { get; set; }
        public DbSet<Amigo> amigos { get; set; }
        public DbSet<Coordenada> coordenadas { get; set; }
    }
}
