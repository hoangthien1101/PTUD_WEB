using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class TrangThaiDatPhongConfig : IEntityTypeConfiguration<TrangThaiDatPhong>
    {
        public void Configure(EntityTypeBuilder<TrangThaiDatPhong> builder)
        {

            builder.ToTable("tbl_TrangThaiDatPhong");

            builder.HasKey(tt => tt.MaTT);

            builder.Property(tt => tt.TenTT)
            .HasMaxLength(50);



        }
    }
}