using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class UtilizadoMapping
    {
        public UtilizadoMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizado>().ToTable("VW_UTILIZADO").HasKey(p => p.UtilizadoId);

            modelBuilder.Entity<Utilizado>().
                Property(p => p.UtilizadoId)
                .HasColumnName("UTILIZADO_ID");

            modelBuilder.Entity<Utilizado>().
                Property(p => p.ValorUtilizado)
                .HasColumnName("VALOR_UTILIZADO");

            modelBuilder.Entity<Utilizado>().
            Property(p => p.ProdutorId)
                .HasColumnName("PRODUTOR_ID");

            modelBuilder.Entity<Utilizado>().
            Property(p => p.DistribuidorId)
                .HasColumnName("DISTRIBUIDOR_ID");
        }
    }
}
