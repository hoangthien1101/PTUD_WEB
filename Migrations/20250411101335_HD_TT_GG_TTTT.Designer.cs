// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webAPI.Data;

#nullable disable

namespace MyWebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250411101335_HD_TT_GG_TTTT")]
    partial class HD_TT_GG_TTTT
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWebApi.Model.CaLam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("GioBatDau")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("GioKetThuc")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("TenCa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_CaLam", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.ChiTietHoaDonDV", b =>
                {
                    b.Property<int>("MaChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTiet"));

                    b.Property<decimal?>("DonGia")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("MaDichVu")
                        .HasColumnType("int");

                    b.Property<int>("MaHD")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("MaChiTiet");

                    b.HasIndex("MaDichVu");

                    b.HasIndex("MaHD");

                    b.ToTable("tbl_ChiTietHoaDonDV", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.ChucVu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tbl_ChucVu", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.DatPhong", b =>
                {
                    b.Property<int>("MaDatPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDatPhong"));

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime");

                    b.Property<int?>("MaKH")
                        .HasColumnType("int");

                    b.Property<int?>("MaPhong")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDat")
                        .HasColumnType("datetime");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<bool?>("Xoa")
                        .HasColumnType("bit");

                    b.HasKey("MaDatPhong");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaPhong");

                    b.HasIndex("TrangThai");

                    b.ToTable("tbl_DatPhong", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.DichVu", b =>
                {
                    b.Property<int>("MaDichVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDichVu"));

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaDichVu");

                    b.ToTable("tbl_DichVu", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.GiamGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("GiaTri")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("LoaiGiam")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenMa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("tbl_GiamGia", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.HoaDon", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHD"));

                    b.Property<int?>("MaGiam")
                        .HasColumnType("int");

                    b.Property<int>("MaKH")
                        .HasColumnType("int");

                    b.Property<int?>("MaPhuongThuc")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayLapHD")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaHD");

                    b.HasIndex("MaGiam");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaPhuongThuc");

                    b.HasIndex("TrangThai");

                    b.ToTable("tbl_HoaDon", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.KhachHang", b =>
                {
                    b.Property<int>("MaKH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKH"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("MaVaiTro")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Xoa")
                        .HasColumnType("bit");

                    b.HasKey("MaKH");

                    b.HasIndex("MaVaiTro");

                    b.ToTable("tbl_KhachHang", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.LoaiPhong", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"));

                    b.Property<decimal?>("GiaPhong")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaLoai");

                    b.ToTable("tbl_LoaiPhong", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.NhanVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaLamId")
                        .HasColumnType("int");

                    b.Property<int?>("ChucVuId")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("LuongCoBan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MaVaiTro")
                        .HasColumnType("int");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CaLamId");

                    b.HasIndex("ChucVuId");

                    b.HasIndex("MaVaiTro");

                    b.ToTable("tbl_NhanVien", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.Phong", b =>
                {
                    b.Property<int>("MaPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhong"));

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int?>("MaLoaiPhong")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SoNguoi")
                        .HasColumnType("int");

                    b.Property<string>("SoPhong")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<bool?>("Xoa")
                        .HasColumnType("bit");

                    b.HasKey("MaPhong");

                    b.HasIndex("MaLoaiPhong");

                    b.HasIndex("TrangThai");

                    b.ToTable("tbl_Phong", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.PhuongThucThanhToan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MoTa")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TenPhuongThuc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("tbl_PhuongThucThanhToan", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.SuDungDichVu", b =>
                {
                    b.Property<int>("MaSDDV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSDDV"));

                    b.Property<int?>("MaDV")
                        .HasColumnType("int");

                    b.Property<int?>("MaKH")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgaySD")
                        .HasColumnType("datetime");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("varchar(200)");

                    b.Property<bool?>("Xoa")
                        .HasColumnType("bit");

                    b.HasKey("MaSDDV");

                    b.HasIndex("MaDV");

                    b.HasIndex("MaKH");

                    b.ToTable("tbl_SuDungDichVu", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.TaiKhoan", b =>
                {
                    b.Property<string>("MaTK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("HinhAnh")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool?>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<int?>("LoaiTK")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TenHienThi")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TenTK")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Xoa")
                        .HasColumnType("bit");

                    b.HasKey("MaTK");

                    b.HasIndex("LoaiTK");

                    b.ToTable("tbl_TaiKhoan", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.TrangThaiDatPhong", b =>
                {
                    b.Property<int>("MaTT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTT"));

                    b.Property<string>("TenTT")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaTT");

                    b.ToTable("tbl_TrangThaiDatPhong", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.TrangThaiPhong", b =>
                {
                    b.Property<int>("MaTT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTT"));

                    b.Property<string>("TenTT")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaTT");

                    b.ToTable("tbl_TrangThaiPhong", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.TrangThaiThanhToan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenTT")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tbl_TrangThaiThanhToan", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.VaiTro", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"));

                    b.Property<string>("TenLoai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaLoai");

                    b.ToTable("tbl_VaiTro", (string)null);
                });

            modelBuilder.Entity("MyWebApi.Model.ChiTietHoaDonDV", b =>
                {
                    b.HasOne("MyWebApi.Model.DichVu", "DichVu")
                        .WithMany("ChiTietHoaDonDVs")
                        .HasForeignKey("MaDichVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApi.Model.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDonDVs")
                        .HasForeignKey("MaHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DichVu");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("MyWebApi.Model.DatPhong", b =>
                {
                    b.HasOne("MyWebApi.Model.KhachHang", "KhachHang")
                        .WithMany("DatPhongs")
                        .HasForeignKey("MaKH");

                    b.HasOne("MyWebApi.Model.Phong", "Phong")
                        .WithMany("DatPhongs")
                        .HasForeignKey("MaPhong");

                    b.HasOne("MyWebApi.Model.TrangThaiDatPhong", "TrangThaiDatPhong")
                        .WithMany("DatPhongs")
                        .HasForeignKey("TrangThai");

                    b.Navigation("KhachHang");

                    b.Navigation("Phong");

                    b.Navigation("TrangThaiDatPhong");
                });

            modelBuilder.Entity("MyWebApi.Model.HoaDon", b =>
                {
                    b.HasOne("MyWebApi.Model.GiamGia", "GiamGia")
                        .WithMany("HoaDons")
                        .HasForeignKey("MaGiam");

                    b.HasOne("MyWebApi.Model.KhachHang", "KhachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApi.Model.PhuongThucThanhToan", "PhuongThucThanhToan")
                        .WithMany("HoaDons")
                        .HasForeignKey("MaPhuongThuc");

                    b.HasOne("MyWebApi.Model.TrangThaiThanhToan", "TrangThaiThanhToan")
                        .WithMany("HoaDons")
                        .HasForeignKey("TrangThai");

                    b.Navigation("GiamGia");

                    b.Navigation("KhachHang");

                    b.Navigation("PhuongThucThanhToan");

                    b.Navigation("TrangThaiThanhToan");
                });

            modelBuilder.Entity("MyWebApi.Model.KhachHang", b =>
                {
                    b.HasOne("MyWebApi.Model.VaiTro", "VaiTro")
                        .WithMany("KhachHangs")
                        .HasForeignKey("MaVaiTro");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("MyWebApi.Model.NhanVien", b =>
                {
                    b.HasOne("MyWebApi.Model.CaLam", "CaLam")
                        .WithMany("NhanViens")
                        .HasForeignKey("CaLamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyWebApi.Model.ChucVu", "ChucVu")
                        .WithMany("NhanViens")
                        .HasForeignKey("ChucVuId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyWebApi.Model.VaiTro", "VaiTro")
                        .WithMany("NhanViens")
                        .HasForeignKey("MaVaiTro");

                    b.Navigation("CaLam");

                    b.Navigation("ChucVu");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("MyWebApi.Model.Phong", b =>
                {
                    b.HasOne("MyWebApi.Model.LoaiPhong", "LoaiPhong")
                        .WithMany("Phongs")
                        .HasForeignKey("MaLoaiPhong");

                    b.HasOne("MyWebApi.Model.TrangThaiPhong", "TrangThaiPhong")
                        .WithMany("Phongs")
                        .HasForeignKey("TrangThai");

                    b.Navigation("LoaiPhong");

                    b.Navigation("TrangThaiPhong");
                });

            modelBuilder.Entity("MyWebApi.Model.SuDungDichVu", b =>
                {
                    b.HasOne("MyWebApi.Model.DichVu", "DichVu")
                        .WithMany("SuDungDichVus")
                        .HasForeignKey("MaDV");

                    b.HasOne("MyWebApi.Model.KhachHang", "KhachHang")
                        .WithMany("SuDungDichVus")
                        .HasForeignKey("MaKH");

                    b.Navigation("DichVu");

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("MyWebApi.Model.TaiKhoan", b =>
                {
                    b.HasOne("MyWebApi.Model.VaiTro", "VaiTro")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("LoaiTK")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("MyWebApi.Model.CaLam", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("MyWebApi.Model.ChucVu", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("MyWebApi.Model.DichVu", b =>
                {
                    b.Navigation("ChiTietHoaDonDVs");

                    b.Navigation("SuDungDichVus");
                });

            modelBuilder.Entity("MyWebApi.Model.GiamGia", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("MyWebApi.Model.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDonDVs");
                });

            modelBuilder.Entity("MyWebApi.Model.KhachHang", b =>
                {
                    b.Navigation("DatPhongs");

                    b.Navigation("HoaDons");

                    b.Navigation("SuDungDichVus");
                });

            modelBuilder.Entity("MyWebApi.Model.LoaiPhong", b =>
                {
                    b.Navigation("Phongs");
                });

            modelBuilder.Entity("MyWebApi.Model.Phong", b =>
                {
                    b.Navigation("DatPhongs");
                });

            modelBuilder.Entity("MyWebApi.Model.PhuongThucThanhToan", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("MyWebApi.Model.TrangThaiDatPhong", b =>
                {
                    b.Navigation("DatPhongs");
                });

            modelBuilder.Entity("MyWebApi.Model.TrangThaiPhong", b =>
                {
                    b.Navigation("Phongs");
                });

            modelBuilder.Entity("MyWebApi.Model.TrangThaiThanhToan", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("MyWebApi.Model.VaiTro", b =>
                {
                    b.Navigation("KhachHangs");

                    b.Navigation("NhanViens");

                    b.Navigation("TaiKhoans");
                });
#pragma warning restore 612, 618
        }
    }
}
