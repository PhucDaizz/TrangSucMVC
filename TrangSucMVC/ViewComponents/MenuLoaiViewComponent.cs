using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TrangSucMVC.Data;
using TrangSucMVC.Views.ViewModels;

namespace TrangSucMVC.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly BanTrangSucContext db;

        public MenuLoaiViewComponent(BanTrangSucContext context) => db = context;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var distinctCategories = await db.SanPhams
                .GroupBy(p => new { p.LoaiSanPham, MaVach = (p.MaVach != null ? p.MaVach : 0) }) // Chuyển đổi rõ ràng từ int? sang int
                .Select(g => new MenuLoaiVM
                {
                    TenLoai = g.Key.LoaiSanPham,
                    MaVach = g.Key.MaVach,
                    SoLuong = g.Count()
                })
                .OrderBy(p => p.TenLoai)
                .ToListAsync();

            return View(distinctCategories);
        }
    }
}
