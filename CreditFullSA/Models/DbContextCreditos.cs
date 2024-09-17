using Microsoft.EntityFrameworkCore;

namespace CreditFullSA.Models
{
    public class DbContextCreditos : DbContext
    {
        public DbContextCreditos(DbContextOptions<DbContextCreditos> options) : base(options)
        {

        }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(new Administrador
            {
                email = "jcruz@gmail.com",
                Nombre = "Jorge Cruz cruz",
                Password = "78963",


            });
            modelBuilder.Entity<Administrador>().HasData(new Administrador
            {
                email = "jvega@gmail.com",
                Nombre = "Jinnet Vega Marin",
                Password = "41936",


            });
        }
    }
}
