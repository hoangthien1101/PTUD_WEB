using MyWebApi.Model;
using webAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.ViewModel
{
    public interface IDatPhongRepo
    {
        List<DatPhongMD> GetAll();
        JsonResult GetById(int id);
        JsonResult Create(AddDatPhong addDatPhong);
        JsonResult Update(int id, UpdateDatPhong updateDatPhong);
        JsonResult Delete(int id, DeleteDatPhong deleteDatPhong);
    }

    public class DatPhongRepo : IDatPhongRepo
    {
        private readonly AppDbContext _context;

        public DatPhongRepo(AppDbContext context)
        {
            _context = context;
        }
        
        public List<DatPhongMD> GetAll()
        {
            var datPhongs = _context.DatPhongs.Select(dp => new DatPhongMD
            {
                MaDatPhong = dp.MaDatPhong,
                MaKH = dp.MaKH,
                MaPhong = dp.MaPhong,
                NgayDat = dp.NgayDat,
                CheckIn = dp.CheckIn,
                CheckOut = dp.CheckOut,
                TrangThai = dp.TrangThai,
                Xoa = dp.Xoa
            }).ToList();
            return datPhongs;
        }

        public JsonResult GetById(int id)
        {
            var datPhong = _context.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return new JsonResult("Không tìm thấy dữ liệu")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var datPhongVM = new DatPhongMD
            {
                MaDatPhong = datPhong.MaDatPhong,
                MaKH = datPhong.MaKH,
                MaPhong = datPhong.MaPhong,
                NgayDat = datPhong.NgayDat,
                CheckIn = datPhong.CheckIn,
                CheckOut = datPhong.CheckOut,
                TrangThai = datPhong.TrangThai,
                Xoa = datPhong.Xoa
            };
            return new JsonResult(datPhongVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        
        public JsonResult Create(AddDatPhong addDatPhong)
        {
            // Kiểm tra nếu ngày check-in và check-out hợp lệ
            if (addDatPhong.CheckIn >= addDatPhong.CheckOut)
            {
                return new JsonResult("Ngày check-in phải nhỏ hơn ngày check-out")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            // Kiểm tra nếu phòng đã được đặt trong khoảng thời gian này
            var existingBooking = _context.DatPhongs
                .Where(d => d.MaPhong == addDatPhong.MaPhong 
                    && d.TrangThai != 5 // 5 là trạng thái "Đã hủy"
                    && ((d.CheckIn <= addDatPhong.CheckIn && d.CheckOut > addDatPhong.CheckIn)
                        || (d.CheckIn < addDatPhong.CheckOut && d.CheckOut >= addDatPhong.CheckOut)
                        || (d.CheckIn >= addDatPhong.CheckIn && d.CheckOut <= addDatPhong.CheckOut)))
                .FirstOrDefault();

            if (existingBooking != null)
            {
                return new JsonResult("Phòng đã được đặt trong khoảng thời gian này")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var datPhong = new DatPhong
            {
                MaKH = addDatPhong.MaKH,
                MaPhong = addDatPhong.MaPhong,  
                NgayDat = DateTime.Now,
                CheckIn = addDatPhong.CheckIn,
                CheckOut = addDatPhong.CheckOut,
                TrangThai = addDatPhong.TrangThai,
                Xoa = false
            };  
            _context.DatPhongs.Add(datPhong);
            _context.SaveChanges();
            return new JsonResult(datPhong)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }   

        public JsonResult Update(int id, UpdateDatPhong updateDatPhong)
        {
            var datPhong = _context.DatPhongs.FirstOrDefault(d => d.MaDatPhong == id);
            if (datPhong == null)
            {
                return new JsonResult("Không tìm thấy đặt phòng")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Kiểm tra nếu ngày check-in và check-out hợp lệ
            if (updateDatPhong.CheckIn >= updateDatPhong.CheckOut)
            {
                return new JsonResult("Ngày check-in phải nhỏ hơn ngày check-out")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            // Kiểm tra nếu phòng đã được đặt trong khoảng thời gian này
            var existingBooking = _context.DatPhongs
                .Where(d => d.MaPhong == updateDatPhong.MaPhong 
                    && d.MaDatPhong != id
                    && d.TrangThai != 5 // 5 là trạng thái "Đã hủy"
                    && ((d.CheckIn <= updateDatPhong.CheckIn && d.CheckOut > updateDatPhong.CheckIn)
                        || (d.CheckIn < updateDatPhong.CheckOut && d.CheckOut >= updateDatPhong.CheckOut)
                        || (d.CheckIn >= updateDatPhong.CheckIn && d.CheckOut <= updateDatPhong.CheckOut)))
                .FirstOrDefault();

            if (existingBooking != null)
            {
                return new JsonResult("Phòng đã được đặt trong khoảng thời gian này")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            datPhong.MaKH = updateDatPhong.MaKH;
            datPhong.MaPhong = updateDatPhong.MaPhong;
            datPhong.NgayDat = DateTime.Now;
            datPhong.CheckIn = updateDatPhong.CheckIn;
            datPhong.CheckOut = updateDatPhong.CheckOut;
            datPhong.TrangThai = updateDatPhong.TrangThai;

            _context.SaveChanges();

            return new JsonResult("Cập nhật đặt phòng thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }       

        public JsonResult Delete(int id, DeleteDatPhong deleteDatPhong)
        {
            var datPhong = _context.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return new JsonResult("Không tìm thấy dữ liệu")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            datPhong.Xoa = deleteDatPhong.Xoa;
            _context.SaveChanges();
            return new JsonResult("Xóa dữ liệu thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}