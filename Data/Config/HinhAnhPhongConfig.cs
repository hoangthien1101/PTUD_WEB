using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class HinhAnhPhongConfig : IEntityTypeConfiguration<HinhAnhPhong>
    {
        public void Configure(EntityTypeBuilder<HinhAnhPhong> builder)
        {
            builder.ToTable("tbl_HinhAnhPhong");

            builder.HasKey(ha => ha.IdHinhAnh);

            builder.Property(ha => ha.path)
                .HasColumnType("varchar(max)");





            builder.HasOne(h => h.Phong)
                .WithMany(p => p.HinhAnhPhongs)
                .HasForeignKey(h => h.MaPhong);



        }
    }
}