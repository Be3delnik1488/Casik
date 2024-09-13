using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication9.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balance> Balances { get; set; }

    public virtual DbSet<Dealer> Dealers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<TypeBook> TypeBooks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;uid=root;Database=mydb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("balance");

            entity.HasIndex(e => e.IdUser, "fk_user_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.History)
                .HasMaxLength(45)
                .HasColumnName("history");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Money)
                .HasMaxLength(45)
                .HasColumnName("money");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Balances)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userb");
        });

        modelBuilder.Entity<Dealer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dealer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game");

            entity.HasIndex(e => e.IdDealer, "fk_dealer_idx");

            entity.HasIndex(e => e.IdType, "fk_type_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDealer).HasColumnName("id_dealer");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.TimeBegin)
                .HasMaxLength(45)
                .HasColumnName("time_begin");
            entity.Property(e => e.TimeEnd)
                .HasMaxLength(45)
                .HasColumnName("time_end");

            entity.HasOne(d => d.IdDealerNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.IdDealer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dealer");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_type");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("player");

            entity.HasIndex(e => e.IdGame, "fk_game");

            entity.HasIndex(e => e.IdUser, "fk_user_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdGame).HasColumnName("id_game");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdGameNavigation).WithMany(p => p.Players)
                .HasForeignKey(d => d.IdGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_game");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Players)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<TypeBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("type_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Rules)
                .HasMaxLength(45)
                .HasColumnName("rules");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
