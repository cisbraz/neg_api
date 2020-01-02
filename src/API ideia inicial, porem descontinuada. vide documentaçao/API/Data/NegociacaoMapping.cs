using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class NegociacaoMapping
    {
        public NegociacaoMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Negociacao>().ToTable("CAPA_NEGOCIACAO").HasKey(p => p.NegociacaoId);

            modelBuilder.Entity<Negociacao>().
                Property(p => p.NegociacaoId)
                .HasColumnName("NEGOCIACAO_ID");

            modelBuilder.Entity<Negociacao>().
                Property(p => p.ProdutorId)
                .HasColumnName("PRODUTOR_ID");

            modelBuilder.Entity<Negociacao>().
            Property(p => p.DistribuidorId)
                .HasColumnName("DISTRIBUIDOR_ID");

            modelBuilder.Entity<Negociacao>().
            Property(p => p.Status)
                .HasColumnName("STATUS");
        }
    }
}
