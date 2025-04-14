using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class ChucVuConfig : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable("tbl_ChucVu");

            builder.HasKey(cv => cv.Id);

            builder.Property(cv => cv.TenChucVu)
                    .HasMaxLength(100)
                    .IsRequired();

        }
    }
}