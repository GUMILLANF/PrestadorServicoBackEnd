using Microsoft.EntityFrameworkCore;
using PrestadorServico.Domain.Entities;

namespace PrestadorServico.Infra.Context
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Servico> Servicos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
      modelBuilder.Entity<Servico>().ToTable("Servicos");
      modelBuilder.Entity<Servico>().Property(e => e.Id);
      modelBuilder.Entity<Servico>().Property(e => e.Titulo).HasMaxLength(100).IsRequired();//.HasColumnType("varchar(100)");
      modelBuilder.Entity<Servico>().Property(e => e.Descricao).IsRequired();
      modelBuilder.Entity<Servico>().Property(e => e.Status).IsRequired();  
      modelBuilder.Entity<Servico>().Property(e => e.Usuario).IsRequired();
      modelBuilder.Entity<Servico>().HasIndex(e => e.Usuario);

      // modelBuilder.Entity<Servico>().HasAlternateKey(e => new { e.Id, e.Usuario});
    }
  }
  
}