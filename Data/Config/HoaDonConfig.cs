using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {


        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("tbl_HoaDon");

            // Primary Key
            builder.HasKey(x => x.MaHD);

            builder.Property(x => x.MaHD)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.MaKH)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.NgayLapHD)
                .HasColumnType("datetime");


            builder.Property(x => x.MaPhuongThuc);


            builder.Property(x => x.MaGiam);


            builder.Property(x => x.TongTien)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.TrangThai)
                .HasColumnType("int");

            // Relationships      KH
            builder.HasOne(x => x.KhachHang)
                .WithMany(kh => kh.HoaDons)
                .HasForeignKey(x => x.MaKH);

            //Giam GIa

            builder.HasOne(x => x.GiamGia)
                .WithMany(gg => gg.HoaDons)
                .HasForeignKey(x => x.MaGiam);



            // Phuong thuc Thanh Toan
            builder.HasOne(x => x.PhuongThucThanhToan)
                .WithMany(pt => pt.HoaDons)
                .HasForeignKey(x => x.MaPhuongThuc);




            //Trang thai thanh toan
            builder.HasOne(x => x.TrangThaiThanhToan)
               .WithMany(tt => tt.HoaDons)
               .HasForeignKey(x => x.TrangThai);

        }
    }
}