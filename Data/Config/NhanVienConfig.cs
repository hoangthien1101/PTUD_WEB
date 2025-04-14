using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
       public class NhanVienConfig : IEntityTypeConfiguration<NhanVien>
       {
              public void Configure(EntityTypeBuilder<NhanVien> builder)
              {
                     builder.ToTable("tbl_NhanVien");

                     builder.HasKey(nv => nv.Id);

                     builder.Property(nv => nv.HoTen)
                            .IsRequired()
                            .HasMaxLength(100);

                     builder.Property(nv => nv.LuongCoBan)
                            .HasColumnType("decimal(18,2)");

                     builder.Property(nv => nv.TrangThai)
                            .HasColumnType("bit");


                     builder.HasOne(nv => nv.ChucVu)
                            .WithMany(cv => cv.NhanViens)
                            .HasForeignKey(nv => nv.ChucVuId)
                            .OnDelete(DeleteBehavior.Restrict);


                     builder.HasOne(nv => nv.CaLam)
                            .WithMany(cl => cl.NhanViens)
                            .HasForeignKey(nv => nv.CaLamId)
                            .OnDelete(DeleteBehavior.Restrict);


                     builder.HasOne(nv => nv.VaiTro)
                            .WithMany(v => v.NhanViens)
                            .HasForeignKey(nv => nv.MaVaiTro);



              }
       }
}