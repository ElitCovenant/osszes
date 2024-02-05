using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KonyvtarBackEnd.Models;

public partial class KonyvtarDbContext : DbContext
{
    public KonyvtarDbContext()
    {
    }

    public KonyvtarDbContext(DbContextOptions<KonyvtarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Felhasznalo> Felhasznalos { get; set; }

    public virtual DbSet<Kiado> Kiados { get; set; }

    public virtual DbSet<KolcsonzesTortenet> KolcsonzesTortenets { get; set; }

    public virtual DbSet<Konyv> Konyvs { get; set; }

    public virtual DbSet<Sorozat> Sorozats { get; set; }

    public virtual DbSet<Szerzo> Szerzos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=library;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_hungarian_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Felhasznalo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("felhasznalo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FelhasznaloiNev)
                .HasMaxLength(45)
                .HasColumnName("felhasznaloi_nev");
            entity.Property(e => e.Jelszo)
                .HasMaxLength(100)
                .HasColumnName("jelszo");
            entity.Property(e => e.Kolcsonozhet)
                .HasDefaultValueSql("'1'")
                .HasColumnName("kolcsonozhet");
            entity.Property(e => e.Nev)
                .HasMaxLength(160)
                .HasColumnName("nev");
            entity.Property(e => e.TagFelvehet)
                .HasDefaultValueSql("'0'")
                .HasColumnName("tag_felvehet");
            entity.Property(e => e.TagsagKezdete)
                .HasColumnType("datetime")
                .HasColumnName("tagsag_kezdete");
            entity.Property(e => e.TagsagVege)
                .HasColumnType("datetime")
                .HasColumnName("tagsag_vege");
        });

        modelBuilder.Entity<Kiado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kiado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(100)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<KolcsonzesTortenet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kolcsonzes_tortenet");

            entity.HasIndex(e => e.KonyvId, "fk_konyv_id_idx");

            entity.HasIndex(e => e.TagId, "fk_tag_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datum)
                .HasColumnType("datetime")
                .HasColumnName("datum");
            entity.Property(e => e.KonyvId).HasColumnName("konyv_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Konyv).WithMany(p => p.KolcsonzesTortenets)
                .HasForeignKey(d => d.KonyvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_kolcsonzes_tortenet_konyv_id");

            entity.HasOne(d => d.Tag).WithMany(p => p.KolcsonzesTortenets)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("fk_kolcsonzes_tortenet_tag_id");
        });

        modelBuilder.Entity<Konyv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("konyv");

            entity.HasIndex(e => e.KiadoId, "fk_kiado_id_idx");

            entity.HasIndex(e => e.SorozatId, "fk_sorozat_id_idx");

            entity.HasIndex(e => e.SzerzoId, "fk_szerzo_id_idx");

            entity.HasIndex(e => e.TagId, "fk_tag_id_idx");

            entity.HasIndex(e => e.RaktariSzam, "raktari_szam_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ar)
                .HasPrecision(10, 2)
                .HasColumnName("ar");
            entity.Property(e => e.BeszerzesDatuma).HasColumnName("beszerzes_datuma");
            entity.Property(e => e.Cim)
                .HasMaxLength(100)
                .HasColumnName("cim");
            entity.Property(e => e.CutterJelzet)
                .HasMaxLength(8)
                .HasColumnName("cutter_jelzet");
            entity.Property(e => e.IsbnSzam)
                .HasColumnType("decimal(13,0) unsigned")
                .HasColumnName("isbn_szam");
            entity.Property(e => e.KiadasEve).HasColumnName("kiadas_eve");
            entity.Property(e => e.KiadoId).HasColumnName("kiado_id");
            entity.Property(e => e.Megjegyzes)
                .HasMaxLength(1000)
                .HasColumnName("megjegyzes");
            entity.Property(e => e.RaktariSzam).HasColumnName("raktari_szam");
            entity.Property(e => e.SorozatId).HasColumnName("sorozat_id");
            entity.Property(e => e.Szakjelzet)
                .HasPrecision(3)
                .HasColumnName("szakjelzet");
            entity.Property(e => e.SzerzoId)
                .HasDefaultValueSql("'34'")
                .HasColumnName("szerzo_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Kiado).WithMany(p => p.Konyvs)
                .HasForeignKey(d => d.KiadoId)
                .HasConstraintName("fk_konyv_kiado_id");

            entity.HasOne(d => d.Sorozat).WithMany(p => p.Konyvs)
                .HasForeignKey(d => d.SorozatId)
                .HasConstraintName("fk_konyv_sorozat_id");

            entity.HasOne(d => d.Szerzo).WithMany(p => p.Konyvs)
                .HasForeignKey(d => d.SzerzoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_konyv_szerzo_id");

            entity.HasOne(d => d.Tag).WithMany(p => p.Konyvs)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("fk_konyv_tag_id");
        });

        modelBuilder.Entity<Sorozat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sorozat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(100)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Szerzo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szerzo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(100)
                .HasColumnName("nev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
