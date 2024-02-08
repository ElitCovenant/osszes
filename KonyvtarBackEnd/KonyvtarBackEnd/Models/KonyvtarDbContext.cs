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

    public virtual DbSet<AccountImg> AccountImgs { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<LoanHistory> LoanHistories { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<Series> Series { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=library;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<AccountImg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("account_img");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImgName)
                .HasMaxLength(100)
                .HasColumnName("img_name");
            entity.Property(e => e.ImgPath)
                .HasMaxLength(100)
                .HasColumnName("img_path");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("book");

            entity.HasIndex(e => e.PublisherId, "fk_kiado_id_idx");

            entity.HasIndex(e => e.SeriesId, "fk_sorozat_id_idx");

            entity.HasIndex(e => e.AuthorId, "fk_szerzo_id_idx");

            entity.HasIndex(e => e.UserId, "fk_tag_id_idx");

            entity.HasIndex(e => e.WarehouseNum, "raktari_szam_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasDefaultValueSql("'34'")
                .HasColumnName("author_id");
            entity.Property(e => e.BookImg)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Valami/Valami'")
                .HasColumnName("book_img");
            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .HasColumnName("comment");
            entity.Property(e => e.CutterJelzet)
                .HasMaxLength(8)
                .HasColumnName("cutter_jelzet");
            entity.Property(e => e.IsbnNum)
                .HasColumnType("decimal(13,0) unsigned")
                .HasColumnName("isbn_num");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.SeriesId).HasColumnName("series_id");
            entity.Property(e => e.Szakkjelzet)
                .HasPrecision(3)
                .HasColumnName("szakkjelzet");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WarehouseNum).HasColumnName("warehouse_num");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_konyv_szerzo_id");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("fk_konyv_kiado_id");

            entity.HasOne(d => d.Series).WithMany(p => p.Books)
                .HasForeignKey(d => d.SeriesId)
                .HasConstraintName("fk_konyv_sorozat_id");

            entity.HasOne(d => d.User).WithMany(p => p.Books)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_konyv_tag_id");
        });

        modelBuilder.Entity<LoanHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("loan_history");

            entity.HasIndex(e => e.BookId, "fk_konyv_id_idx");

            entity.HasIndex(e => e.UserId, "fk_tag_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasColumnName("comment");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.Returned).HasColumnName("returned");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.LoanHistories)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_kolcsonzes_tortenet_konyv_id");

            entity.HasOne(d => d.User).WithMany(p => p.LoanHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_kolcsonzes_tortenet_tag_id");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("publisher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("series");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.IdAccountImg, "id_account_img");

            entity.HasIndex(e => e.IdRule, "id_rule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Hash)
                .HasMaxLength(65)
                .HasColumnName("HASH");
            entity.Property(e => e.IdAccountImg)
                .HasDefaultValueSql("'4'")
                .HasColumnName("id_account_img");
            entity.Property(e => e.IdRule)
                .HasDefaultValueSql("'2'")
                .HasColumnName("id_rule");
            entity.Property(e => e.MembershipEnd).HasColumnName("membership_end");
            entity.Property(e => e.MembershipStart).HasColumnName("membership_start");
            entity.Property(e => e.Token)
                .HasMaxLength(1000)
                .HasColumnName("token");
            entity.Property(e => e.Usarname)
                .HasMaxLength(45)
                .HasColumnName("usarname");

            entity.HasOne(d => d.IdAccountImgNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdAccountImg)
                .HasConstraintName("user_ibfk_2");

            entity.HasOne(d => d.IdRuleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRule)
                .HasConstraintName("user_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
