using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
       public class TaiKhoanConfig : IEntityTypeConfiguration<TaiKhoan>
       {
              public void Configure(EntityTypeBuilder<TaiKhoan> builder)
              {
                     builder.ToTable("tbl_TaiKhoan");

                     builder.HasKey(t => t.MaTK);

                     builder.Property(t => t.TenTK)
                            .HasMaxLength(100)
                            .IsUnicode(false);

                     builder.Property(t => t.MatKhau)
                            .HasMaxLength(200)
                            .IsUnicode(false);

                     builder.Property(t => t.HinhAnh)
                            .IsUnicode(false);

                     builder.Property(t => t.TenHienThi)
                            .HasMaxLength(150);

                     builder.Property(t => t.Phone)
                            .HasMaxLength(20)
                            .IsUnicode(false);

                     builder.Property(t => t.Email)
                            .HasMaxLength(100)
                            .IsUnicode(false);


                     builder.Property(t => t.IsVerified)
                            .HasColumnType("bit");


                     builder.Property(t => t.Xoa)
                            .HasColumnType("bit");


                     builder.Property(t => t.CreateAt)
                            .HasColumnType("datetime");


                     builder.HasOne(t => t.VaiTro)
                             .WithMany(v => v.TaiKhoans)
                             .HasForeignKey(t => t.LoaiTK)
                             .OnDelete(DeleteBehavior.Restrict);

              }
       }
}