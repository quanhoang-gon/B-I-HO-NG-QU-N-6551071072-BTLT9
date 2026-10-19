using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TraSuaApp.Models;

public partial class QLTraSuaContext : DbContext
{
    public QLTraSuaContext()
    {
    }

    public QLTraSuaContext(DbContextOptions<QLTraSuaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<DanhMucMon> DanhMucMons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<Mon> Mons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaMon }).HasName("PK__ChiTietH__B480147A24219E79");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHoa__MaHD__5441852A");

            entity.HasOne(d => d.MaMonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaMon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaMon__5535A963");
        });

        modelBuilder.Entity<DanhMucMon>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DanhMucM__2725866E5F6FA6C6");

            entity.ToTable("DanhMucMon");

            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenDm)
                .HasMaxLength(50)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E0530A499F");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.DaThanhToan).HasDefaultValue(true);
            entity.Property(e => e.GioLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HinhThuc).HasMaxLength(20);
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Mon>(entity =>
        {
            entity.HasKey(e => e.MaMon).HasName("PK__Mon__3A5B29A8A2366623");

            entity.ToTable("Mon");

            entity.Property(e => e.DangBan).HasDefaultValue(true);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenMon).HasMaxLength(100);

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.Mons)
                .HasForeignKey(d => d.MaDm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mon__MaDM__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
