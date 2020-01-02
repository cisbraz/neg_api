using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class ProdutorMapping
    {
        public ProdutorMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produtor>().ToTable("PRODUTOR").HasKey(p => p.ProdutorId);

            modelBuilder.Entity<Produtor>().
                Property(p => p.ProdutorId)
                .HasColumnName("PRODUTOR_ID");

            modelBuilder.Entity<Produtor>().
            Property(p => p.RazaoSocial)
                .HasColumnName("RAZAO_SOCIAL");

            modelBuilder.Entity<Produtor>().
            Property(p => p.Ativo)
                .HasColumnName("ATIVO");
        }
    }
}
