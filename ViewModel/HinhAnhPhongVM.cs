using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class HinhAnhPhongVM
    {

        public string? path { get; set; }
        public bool? isUsed { get; set; }

        public int MaPhong { get; set; }


    }
    public class HinhAnhPhongMD : HinhAnhPhongVM
    {
        public int IdHinhAnh { get; set; }
        public virtual Phong Phong { get; set; }
    }

    public class AddHinhAnh
    {
        public string? path { get; set; }
        public bool? isUsed { get; set; }
        public int MaPhong { get; set; }
    }

    public class UpdateHinhAnh
    {
        public string? path { get; set; }
        public bool? isUsed { get; set; }
    }
}