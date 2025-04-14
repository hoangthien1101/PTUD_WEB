using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebApi.Model;

namespace MyWebApi.Data.Config
{
    public class CaLamConfig : IEntityTypeConfiguration<CaLam>
    {


        public void Configure(EntityTypeBuilder<CaLam> builder)
        {
            builder.ToTable("tbl_CaLam");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.TenCa)
                   .IsRequired()
                   .HasMaxLength(50);


            builder.Property(c => c.GioBatDau)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(c => c.GioKetThuc)
                   .HasColumnType("datetime")
                   .IsRequired();
        }
    }
}