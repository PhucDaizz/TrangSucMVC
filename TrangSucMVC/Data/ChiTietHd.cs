using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class ChiTietHd
{
    public string MaCt { get; set; } = null!;

    public decimal? DonGia { get; set; }

    public int? SoLuong { get; set; }

    public decimal? GiamGia { get; set; }

    public string? MaDonHang { get; set; }

    public string? MaSanPham { get; set; }

    public virtual HoaDon? MaDonHangNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
