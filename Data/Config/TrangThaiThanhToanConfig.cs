using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class TrangThaiThanhToanConfig : IEntityTypeConfiguration<TrangThaiThanhToan>
    {
        public void Configure(EntityTypeBuilder<TrangThaiThanhToan> builder)
        {

            builder.ToTable("tbl_TrangThaiThanhToan");

            builder.HasKey(tt => tt.Id);

            builder.Property(tt => tt.TenTT)
            .HasMaxLength(100);


            



        }
    }
}