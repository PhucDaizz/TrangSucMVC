using Microsoft.AspNetCore.Mvc;
using TrangSucMVC.Data;
using TrangSucMVC.Views.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TrangSucMVC.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly BanTrangSucContext db;

        public SanPhamController(BanTrangSucContext context)
        {
            db = context;
        }

        public IActionResult Index(int? loai)
        {
            var sanPhams = db.SanPhams.AsQueryable();

            if (loai.HasValue)
            {
                sanPhams = sanPhams.Where(p => p.MaVach == loai.Value);
            }

            var result = sanPhams.Select(p => new SanPhamVM
            {
                MaSanPham = p.MaSanPham,
                TenSanPham = p.TenSanPham ?? "",
                Hinh = p.Hinh ?? "",
                GiaBan = p.GiaBan ?? 0,
                ThoiGianBaoHanh = p.ThoiGianBaoHanh ?? 0,
                LoaiSanPham = p.LoaiSanPham ?? ""
            }).ToList();

            return View(result);
        }

        public IActionResult Search(string? query)
        {
			var sanPhams = db.SanPhams.AsQueryable();

			if (query != null)
			{
				sanPhams = sanPhams.Where(p => p.TenSanPham.Contains(query));
			}

			var result = sanPhams.Select(p => new SanPhamVM
			{
				MaSanPham = p.MaSanPham,
				TenSanPham = p.TenSanPham ?? "",
				Hinh = p.Hinh ?? "",
				GiaBan = p.GiaBan ?? 0,
				ThoiGianBaoHanh = p.ThoiGianBaoHanh ?? 0,
				LoaiSanPham = p.LoaiSanPham ?? ""
			});

			return View(result);
		}

        public IActionResult Detail(string id)
        {
            var data = db.SanPhams
                .SingleOrDefault(p => p.MaSanPham == id);

            if (data == null)
            {
                TempData["Message"] = $"Không thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }

            var result = new ChiTietSanPhamVM
            {
                MaSanPham = data.MaSanPham,
                TenSanPham = data.TenSanPham,
                GiaBan = data.GiaBan ?? 0,
                ChiTiet = "Đang được cập nhật - coming soon",
                Hinh = data.Hinh ?? string.Empty,
                LoaiSanPham = data.LoaiSanPham,
                DiemDanhGia = 5,
                SoLuongTon = 10
            };

            return View(result);
        }


    }
}
