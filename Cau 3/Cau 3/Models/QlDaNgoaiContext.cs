using System;
using System.Collections.Generic;
using Cau_3.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Cau_3.Models;

public partial class QlDaNgoaiContext : DbContext
{
    public QlDaNgoaiContext()
    {
    }

    public QlDaNgoaiContext(DbContextOptions<QlDaNgoaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChuyenDi> ChuyenDis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuyenDi>(entity =>
        {
            entity.HasKey(e => e.MaChuyen).HasName("PK__ChuyenDi__0ED32A479A32A530");

            entity.ToTable("ChuyenDi");

            entity.Property(e => e.DiaDiem).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.NganSach).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PhuongTien).HasMaxLength(30);
            entity.Property(e => e.SoNguoi).HasDefaultValue(1);
            entity.Property(e => e.TenChuyen).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
