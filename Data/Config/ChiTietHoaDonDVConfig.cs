using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class ChiTietHoaDonDVConfig : IEntityTypeConfiguration<ChiTietHoaDonDV>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDonDV> builder)
        {
            builder.ToTable("tbl_ChiTietHoaDonDV");

            builder.HasKey(ct => ct.MaChiTiet);


            builder.Property(ct => ct.SoLuong)
            .HasColumnType("int");


            builder.Property(ct => ct.DonGia)
            .HasColumnType("decimal(10,2)");


            builder.Property(ct => ct.ThanhTien)
            .HasColumnType("decimal(10,2)");


            builder.HasOne(ct => ct.HoaDon)
            .WithMany(hd => hd.ChiTietHoaDonDVs)
            .HasForeignKey(ct => ct.MaHD);


            builder.HasOne(ct => ct.HoaDon)
            .WithMany(hd => hd.ChiTietHoaDonDVs)
            .HasForeignKey(ct => ct.MaHD);


            builder.HasOne(ct => ct.DichVu)
            .WithMany(dv => dv.ChiTietHoaDonDVs)
            .HasForeignKey(ct => ct.MaDichVu);


        }
    }
}