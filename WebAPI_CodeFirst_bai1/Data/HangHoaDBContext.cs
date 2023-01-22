using Microsoft.EntityFrameworkCore;
using WebAPI_CodeFirst_bai1.Models;

namespace WebAPI_CodeFirst_bai1.Data
{
    public class HangHoaDBContext : DbContext
    {
        public HangHoaDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(
                e =>
                {
                    e.ToTable("DonHang");
                    e.HasKey(dh => dh.Id);
                    e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                    e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
                });

            modelBuilder.Entity<DonHangChiTiet>(e => {
                e.ToTable("DonHangChiTiet");
                e.HasKey(k => new {k.HangHoaId, k.MaDonHangId});

                e.HasOne(d => d.DonHang).WithMany(d => d.DonHangChiTiet).HasForeignKey(d => d.MaDonHangId).HasConstraintName("PK_DonHangChiTiet_DonHang");

                e.HasOne(k => k.HangHoa).WithMany(d => d.DonHangChiTiets).HasForeignKey(d => d.HangHoaId).HasConstraintName("PK_DonHangChiTiet_HangHoa");
            });
        }

        public DbSet<HangHoa> HangHoa { set; get; }
        public DbSet<Loai> Loai { set; get; }
        public DbSet<DonHang> DonHang { set; get;}
        public DbSet<DonHangChiTiet> DonHangChiTiet { set; get; }
    }

}
