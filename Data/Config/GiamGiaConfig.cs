using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class GiamGiaConfig : IEntityTypeConfiguration<GiamGia>
    {
        public void Configure(EntityTypeBuilder<GiamGia> builder)
        {
            builder.ToTable("tbl_GiamGia");

            builder.HasKey(gg => gg.Id);


            builder.Property(gg => gg.TenMa)
            .HasMaxLength(100);

            builder.Property(gg => gg.LoaiGiam)
            .HasMaxLength(50);

            builder.Property(gg => gg.GiaTri)
            .HasColumnType("decimal(10,2)");

            builder.Property(gg => gg.NgayBatDau)
            .HasColumnType("datetime");

            builder.Property(gg => gg.NgayKetThuc)
            .HasColumnType("datetime");


        }
    }
}