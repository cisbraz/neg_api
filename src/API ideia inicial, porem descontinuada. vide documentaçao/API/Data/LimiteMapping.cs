using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class LimiteMapping
    {
        public LimiteMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Limite>().ToTable("VW_LIMITE").HasKey(p => p.LimiteId);

            modelBuilder.Entity<Limite>().
                Property(p => p.LimiteId)
                .HasColumnName("LIMITE_ID");

            modelBuilder.Entity<Limite>().
                Property(p => p.ValorLimite)
                .HasColumnName("VALOR_LIMITE");

            modelBuilder.Entity<Limite>().
            Property(p => p.ProdutorId)
                .HasColumnName("PRODUTOR_ID");

            modelBuilder.Entity<Limite>().
            Property(p => p.DistribuidorId)
                .HasColumnName("DISTRIBUIDOR_ID");
        }
    }
}
