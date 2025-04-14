using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class SuDungDichVuConfig : IEntityTypeConfiguration<SuDungDichVu>
    {


        public void Configure(EntityTypeBuilder<SuDungDichVu> builder)
        {
            builder.ToTable("tbl_SuDungDichVu");

            builder.HasKey(x => x.MaSDDV);


            builder.Property(x => x.MaKH)
                .HasColumnType("int");

            builder.Property(x => x.MaDV)
                .HasColumnType("int");


            builder.Property(x => x.NgaySD)
                .HasColumnType("datetime");


            builder.Property(x => x.SoLuong)
                .HasColumnType("int");

            builder.Property(x => x.ThanhTien)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.TrangThai)
                .HasColumnType("varchar(200)");

            builder.Property(t => t.Xoa)
                        .HasColumnType("bit");



            builder.HasOne(sd => sd.DichVu)
                .WithMany(dv => dv.SuDungDichVus)
                .HasForeignKey(sd => sd.MaDV);

            builder.HasOne(sd => sd.KhachHang)
                .WithMany(kh => kh.SuDungDichVus)
                .HasForeignKey(sd => sd.MaKH);
        }
    }

}
