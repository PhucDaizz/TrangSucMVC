using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class SanPham
{
    public string MaSanPham { get; set; } = null!;

    public string? TenSanPham { get; set; }

    public int MaVach { get; set; }

    public decimal? GiaVangTaiThoiDiem { get; set; }

    public decimal? TrongLuong { get; set; }

    public decimal? TienCong { get; set; }

    public decimal? TienDa { get; set; }

    public decimal? GiaBan { get; set; }

    public int? ThoiGianBaoHanh { get; set; }

    public string? LoaiSanPham { get; set; }

    public int? SoLuongTonKho { get; set; }

    public string? Hinh { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();
}
