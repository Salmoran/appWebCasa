using ClaseCasa.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaseCasa2.Context
{
    public class ConexionSQLServer:DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options)
        {

        }
        public DbSet<CasaModel> Casa { get; set; } = null!;
        public DbSet<CuartoModel> Cuarto { get; set; } = null!;
        public DbSet<TipoCuartoModel> TipoCuarto { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CasaModel>()
                .HasMany(e => e.Cuartos)
                .WithOne(ed => ed.CasaModel)
                .HasForeignKey(e => e.IdCasa)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}