using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Royal_Games.Domains;

namespace Royal_Games.Contexts;

public partial class Royal_GamesContext : DbContext
{
    public Royal_GamesContext()
    {
    }

    public Royal_GamesContext(DbContextOptions<Royal_GamesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassIndicativa> ClassIndicativa { get; set; }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<Jogo> Jogo { get; set; }

    public virtual DbSet<Log_AlteracaoJogo> Log_AlteracaoJogo { get; set; }

    public virtual DbSet<Plataforma> Plataforma { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=D06S31-1313863\\SQLEXPRRESS;Database=Royal_Games;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassIndicativa>(entity =>
        {
            entity.HasKey(e => e.ClassIndicativaID).HasName("PK__ClassInd__3AADF40CCF705EF5");

            entity.Property(e => e.Nome)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroID).HasName("PK__Genero__A99D0268102937FA");

            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.JogoID).HasName("PK__Jogo__59196855C1D001F9");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_AlteracaoJogo");
                    tb.HasTrigger("trg_ExclusaoJogo");
                });

            entity.HasIndex(e => e.Nome, "UQ__Jogo__7D8FE3B2347027D7").IsUnique();

            entity.Property(e => e.Descricao).HasMaxLength(2000);
            entity.Property(e => e.Nome)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StatusJogo).HasDefaultValue(true);

            entity.HasOne(d => d.Class_Indicativa).WithMany(p => p.Jogo)
                .HasForeignKey(d => d.Class_IndicativaID)
                .HasConstraintName("FK__Jogo__Class_Indi__534D60F1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Jogo)
                .HasForeignKey(d => d.UsuarioID)
                .HasConstraintName("FK__Jogo__UsuarioID__52593CB8");

            entity.HasMany(d => d.Genero).WithMany(p => p.Jogo)
                .UsingEntity<Dictionary<string, object>>(
                    "JogoGenero",
                    r => r.HasOne<Genero>().WithMany()
                        .HasForeignKey("GeneroID")
                        .HasConstraintName("FK_JogoGenero_Genero"),
                    l => l.HasOne<Jogo>().WithMany()
                        .HasForeignKey("JogoID")
                        .HasConstraintName("FK_JogoGenero_Jogo"),
                    j =>
                    {
                        j.HasKey("JogoID", "GeneroID");
                    });

            entity.HasMany(d => d.Plataforma).WithMany(p => p.Jogo)
                .UsingEntity<Dictionary<string, object>>(
                    "JogoPlataforma",
                    r => r.HasOne<Plataforma>().WithMany()
                        .HasForeignKey("PlataformaID")
                        .HasConstraintName("FK_JogoPlataforma_Plataforma"),
                    l => l.HasOne<Jogo>().WithMany()
                        .HasForeignKey("JogoID")
                        .HasConstraintName("FK_JogoPlataforma_Jogo"),
                    j =>
                    {
                        j.HasKey("JogoID", "PlataformaID");
                    });
        });

        modelBuilder.Entity<Log_AlteracaoJogo>(entity =>
        {
            entity.HasKey(e => e.Log_AlteracaoJogoID).HasName("PK__Log_Alte__BB9D2C4F166D3445");

            entity.Property(e => e.DataAlteracao).HasPrecision(0);
            entity.Property(e => e.NomeAnterior)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.PrecoAnterior).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Jogo).WithMany(p => p.Log_AlteracaoJogo)
                .HasForeignKey(d => d.JogoID)
                .HasConstraintName("FK__Log_Alter__JogoI__59FA5E80");
        });

        modelBuilder.Entity<Plataforma>(entity =>
        {
            entity.HasKey(e => e.PlataformaID).HasName("PK__Platafor__B835678D7AD0C6E9");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE798C09BB3F4");

            entity.ToTable(tb => tb.HasTrigger("trg_ExclusaoUsuario"));

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105346D8858B2").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(125)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(32);
            entity.Property(e => e.StatusUsuario).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
