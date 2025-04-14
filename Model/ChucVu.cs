using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    [Table("tbl_ChucVu")]
    public class ChucVu
    {
        public int Id { get; set; }
        public string? TenChucVu { get; set; }

        // Navigation property
        public ICollection<NhanVien> NhanViens { get; set; }

    }
}