using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class DonHang
{
    public string MaDonHang { get; set; } = null!;

    public DateOnly? NgayDatHang { get; set; }

    public string? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public decimal? TongSoTien { get; set; }

    public decimal? ChietKhau { get; set; }

    public decimal? SoTienCuoiCung { get; set; }

    public string? PhuongThucThanhToan { get; set; }
}
