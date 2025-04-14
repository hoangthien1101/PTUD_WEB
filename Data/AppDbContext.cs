using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data.Config;
using MyWebApi.Model;




namespace webAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<VaiTro> VaiTros { get; set; }

        public DbSet<NhanVien> NhanViens { get; set; }

        public DbSet<CaLam> CaLams { get; set; }

        public DbSet<ChucVu> ChucVus { get; set; }

        public DbSet<LoaiPhong> LoaiPhongs { get; set; }

        public DbSet<Phong> Phongs { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<TrangThaiDatPhong> TrangThaiDatPhongs { get; set; }
        public DbSet<DatPhong> DatPhongs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TaiKhoanConfig());
            modelBuilder.ApplyConfiguration(new VaiTroConfig());
            modelBuilder.ApplyConfiguration(new NhanVienConfig());
            modelBuilder.ApplyConfiguration(new ChucVuConfig());
            modelBuilder.ApplyConfiguration(new CaLamConfig());
            modelBuilder.ApplyConfiguration(new PhongConfig());
            modelBuilder.ApplyConfiguration(new TrangThaiPhongConfig());
            modelBuilder.ApplyConfiguration(new LoaiPhongConfig());
            modelBuilder.ApplyConfiguration(new DatPhongConfig());
            modelBuilder.ApplyConfiguration(new KhachHangConfig());
            modelBuilder.ApplyConfiguration(new TrangThaiDatPhongConfig());
            modelBuilder.ApplyConfiguration(new SuDungDichVuConfig());
            modelBuilder.ApplyConfiguration(new DichVuConfig());
            modelBuilder.ApplyConfiguration(new GiamGiaConfig());
            modelBuilder.ApplyConfiguration(new TrangThaiThanhToanConfig());
            modelBuilder.ApplyConfiguration(new HoaDonConfig());
            modelBuilder.ApplyConfiguration(new PhuongThucThanhToanConfig());
            modelBuilder.ApplyConfiguration(new ChiTietHoaDonDVConfig());

            base.OnModelCreating(modelBuilder);



        }

    }
}