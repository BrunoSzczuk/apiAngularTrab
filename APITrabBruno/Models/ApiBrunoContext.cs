using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APITrabBruno.Models
{
    public partial class ApiBrunoContext : DbContext
    {
        public ApiBrunoContext()
        {
        }

        public ApiBrunoContext(DbContextOptions<ApiBrunoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=apibruno;Username=aplicacao;Password=aplicacao01");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ativo).HasColumnName("ativo").HasDefaultValue(true); 

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100);

                entity.Property(e => e.Numerohabitantes).HasColumnName("numerohabitantes");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('pessoa_id_seq'::regclass)");

                entity.Property(e => e.Ativo).HasColumnName("ativo").HasDefaultValue(true); 

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100);
            });

            modelBuilder.HasSequence("pessoa_id_seq");
        }
    }
}
