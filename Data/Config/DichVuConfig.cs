using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class DichVuConfig : IEntityTypeConfiguration<DichVu>
    {


        public void Configure(EntityTypeBuilder<DichVu> builder)
        {
            builder.ToTable("tbl_DichVu");

            builder.HasKey(x => x.MaDichVu);

            builder.Property(x => x.Ten)
                .HasColumnType("nvarchar(200)");


            builder.Property(x => x.HinhAnh)
                .HasColumnType("nvarchar(max)");


            builder.Property(x => x.MoTa)
                .HasColumnType("nvarchar(200)");


            builder.Property(x => x.Gia)
                .HasColumnType("decimal(10,2)");






        }
    }
}