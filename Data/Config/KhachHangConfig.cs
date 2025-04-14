using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class KhachHangConfig : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("tbl_KhachHang");

            builder.HasKey(k => k.MaKH);

            builder.Property(k => k.TenKH)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true); // nvarchar



            builder.Property(k => k.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(k => k.Phone)
                .HasMaxLength(20)
                .IsUnicode(false); // varchar


            builder.HasOne(kh => kh.VaiTro)
            .WithMany(v => v.KhachHangs)
            .HasForeignKey(kh => kh.MaVaiTro);


        }
    }
}