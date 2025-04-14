using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class VaiTroConfig : IEntityTypeConfiguration<VaiTro>
    {

        public void Configure(EntityTypeBuilder<VaiTro> builder)
        {
            builder.ToTable("tbl_VaiTro");

            builder.HasKey(v => v.MaLoai);

            builder.Property(v => v.TenLoai)
               .HasMaxLength(100);


            







        }
    }
}