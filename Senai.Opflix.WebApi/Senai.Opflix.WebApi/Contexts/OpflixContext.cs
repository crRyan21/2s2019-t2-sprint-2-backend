using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class OpflixContext : DbContext
    {
        public OpflixContext()
        {
        }

        public OpflixContext(DbContextOptions<OpflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<TipoTitulo> TipoTitulo { get; set; }
        public virtual DbSet<TipoUser> TipoUser { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ListaFavoritos> ListaFavoritos { get; set; }

        // Unable to generate entity type for table 'dbo.ListaFavoritos'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=M_Opflix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListaFavoritos>().HasKey(p => new { p.IdUsuario, p.IdLancamento });

            modelBuilder.Entity<ListaFavoritos>()
            .HasOne<Usuarios>(sc => sc.Usuario)
            .WithMany(s => s.ListaFavoritos)
            .HasForeignKey(sc => sc.IdUsuario);


            modelBuilder.Entity<ListaFavoritos>()
                .HasOne<Lancamentos>(sc => sc.Lancamentos)
                .WithMany(s => s.ListaFavoritos)
                .HasForeignKey(sc => sc.IdLancamento);


            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Duracao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__5535A963");

                entity.HasOne(d => d.IdPlataformNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdPlataform)
                    .HasConstraintName("FK__Lancament__IdPla__5629CD9C");

                entity.HasOne(d => d.IdTipoTituloNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdTipoTitulo)
                    .HasConstraintName("FK__Lancament__IdTip__5441852A");
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataform);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoTitulo>(entity =>
            {
                entity.HasKey(e => e.IdTipoTitulo);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUser>(entity =>
            {
                entity.HasKey(e => e.IdTipoUser);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUserNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUser)
                    .HasConstraintName("FK__Usuarios__IdTipo__4BAC3F29");
            });
        }
    }
}
