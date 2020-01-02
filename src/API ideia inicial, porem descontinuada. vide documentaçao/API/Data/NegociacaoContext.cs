using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using API.Models;

namespace API.Data
{
    public class NegociacaoContext : DbContext
    {
        public NegociacaoContext(DbContextOptions<NegociacaoContext> options) : base(options) { }
        public DbSet<Produtor> Produtor { get; set; }
        public DbSet<Limite> Limite { get; set; }
        public DbSet<Utilizado> Utilizado { get; set; }
        public DbSet<Negociacao> Negociacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProdutorMapping(modelBuilder);
            new LimiteMapping(modelBuilder);
            new NegociacaoMapping(modelBuilder);
            new UtilizadoMapping(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            optionsBuilder.UseFirebird(Configuration["ConnectionString"]);
        }
    }
}
