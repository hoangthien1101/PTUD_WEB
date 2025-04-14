using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Model
{
    [Table("tbl_CaLam")]
    public class CaLam
    {
        public int Id { get; set; }
        public string? TenCa { get; set; }
        public DateTime? GioBatDau { get; set; }
        public DateTime? GioKetThuc { get; set; }

        // Navigation property
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}