using System;
using System.Collections.Generic;
using Cau_2.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Cau_2.Models;

public partial class QlNhaTroContext : DbContext
{
    public QlNhaTroContext()
    {
    }

    public QlNhaTroContext(DbContextOptions<QlNhaTroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KhachThue> KhachThues { get; set; }

    public virtual DbSet<PhongTro> PhongTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KhachThue>(entity =>
        {
            entity.HasKey(e => e.MaKhach).HasName("PK__KhachThu__D0CB8DDD517F1DCE");

            entity.ToTable("KhachThue");

            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenPhuongXa).HasMaxLength(100);
            entity.Property(e => e.TenTinh).HasMaxLength(100);

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.KhachThues)
                .HasForeignKey(d => d.MaPhong)
                .HasConstraintName("FK_KhachThue_PhongTro");
        });

        modelBuilder.Entity<PhongTro>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__PhongTro__20BD5E5BC60029DF");

            entity.ToTable("PhongTro");

            entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TenPhong).HasMaxLength(20);
            entity.Property(e => e.TinhTrang).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
