using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class PhuongThucThanhToanConfig : IEntityTypeConfiguration<PhuongThucThanhToan>
    {
        public void Configure(EntityTypeBuilder<PhuongThucThanhToan> builder)
        {
            builder.ToTable("tbl_PhuongThucThanhToan");

            builder.HasKey(pt => pt.Id);


            builder.Property(pt => pt.TenPhuongThuc)
            .HasMaxLength(100);

            builder.Property(pt => pt.MoTa)
            .HasMaxLength(150);

            builder.Property(pt => pt.TrangThai)
            .HasColumnType("bit");




        }
    }
}