using Microsoft.AspNetCore.Mvc;
using TrangSucMVC.Data;
using TrangSucMVC.Views.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrangSucMVC.Components
{
    public class SaleProductsViewComponent : ViewComponent
    {
        private readonly BanTrangSucContext _context;

        public SaleProductsViewComponent(BanTrangSucContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var saleProducts = await _context.SanPhams
                .Where(sp => sp.SoLuongTonKho > 6)
                .OrderByDescending(sp => sp.GiaBan)
                .Take(3)
                .Select(sp => new SanPhamVM
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham ?? "",
                    Hinh = sp.Hinh ?? "",
                    GiaBan = sp.GiaBan ?? 0,
                    ThoiGianBaoHanh = sp.ThoiGianBaoHanh ?? 0,
                    LoaiSanPham = sp.LoaiSanPham ?? ""
                })
                .ToListAsync();

            return View(saleProducts);
        }
    }
}
