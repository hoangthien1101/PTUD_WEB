using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class PhongConfig : IEntityTypeConfiguration<Phong>
    {
        public void Configure(EntityTypeBuilder<Phong> builder)
        {

            builder.ToTable("tbl_Phong");

            builder.HasKey(p => p.MaPhong);

            builder.Property(p => p.SoPhong)
                .HasMaxLength(50);

            builder.Property(p => p.HinhAnh)
                .HasColumnType("nvarchar(MAX)");

            builder.Property(p => p.MoTa)
                .HasMaxLength(200);





            builder.HasOne(p => p.TrangThaiPhong)
                .WithMany(ttp => ttp.Phongs)
                .HasForeignKey(p => p.TrangThai);

            builder.HasOne(p => p.LoaiPhong)
                .WithMany(ml => ml.Phongs)
                .HasForeignKey(p => p.MaLoaiPhong);


        }
    }
}