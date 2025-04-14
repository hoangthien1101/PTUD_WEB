using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
       public class DatPhongConfig : IEntityTypeConfiguration<DatPhong>
       {
              public void Configure(EntityTypeBuilder<DatPhong> builder)
              {
                     builder.ToTable("tbl_DatPhong");

                     builder.HasKey(d => d.MaDatPhong);


                     builder.Property(d => d.NgayDat)
                            .HasColumnType("datetime");

                     builder.Property(d => d.CheckIn)
                            .HasColumnType("datetime");

                     builder.Property(d => d.CheckOut)
                            .HasColumnType("datetime");

                     builder.Property(t => t.Xoa)
                            .HasColumnType("bit");



                     builder.HasOne(dp => dp.Phong)
                            .WithMany(p => p.DatPhongs)
                            .HasForeignKey(dp => dp.MaPhong);

                     builder.HasOne(dp => dp.TrangThaiDatPhong)
                            .WithMany(tt => tt.DatPhongs)
                            .HasForeignKey(dp => dp.TrangThai);

                     builder.HasOne(dp => dp.KhachHang)
                            .WithMany(kh => kh.DatPhongs)
                            .HasForeignKey(dp => dp.MaKH);



              }
       }
}