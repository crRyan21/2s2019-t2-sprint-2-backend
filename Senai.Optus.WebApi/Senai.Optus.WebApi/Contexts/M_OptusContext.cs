using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Optus.WebApi.Domains
{
    public partial class M_OptusContext : DbContext
    {
        public M_OptusContext()
        {
        }

        public M_OptusContext(DbContextOptions<M_OptusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artistas> Artistas { get; set; }
        public virtual DbSet<Estilos> Estilos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=M_Optus;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artistas>(entity =>
            {
                entity.HasKey(e => e.IdArtista);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Artistas__7D8FE3B2CD31422F")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstiloNavigation)
                    .WithMany(p => p.Artistas)
                    .HasForeignKey(d => d.IdEstilo)
                    .HasConstraintName("FK__Artistas__IdEsti__4D94879B");
            });

            modelBuilder.Entity<Estilos>(entity =>
            {
                entity.HasKey(e => e.IdEstilo);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Estilos__7D8FE3B2106E6A84")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105343A1956D1")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
