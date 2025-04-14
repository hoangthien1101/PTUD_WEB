using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class LoaiPhongConfig : IEntityTypeConfiguration<LoaiPhong>
    {
        public void Configure(EntityTypeBuilder<LoaiPhong> builder)
        {
            builder.ToTable("tbl_LoaiPhong");

            builder.HasKey(lp => lp.MaLoai);

            builder.Property(lp => lp.TenLoai)
               .HasMaxLength(100);

            

            builder.Property(lp => lp.GiaPhong)
            .HasColumnType("decimal(10,2)");
        }
    }
}