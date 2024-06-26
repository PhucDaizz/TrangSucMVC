using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class HoaDon
{
    public string MaDonHang { get; set; } = null!;

    public DateOnly? NgayDatHang { get; set; }

    public string? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public decimal? TongSoTien { get; set; }

    public decimal? ChietKhau { get; set; }

    public decimal? SoTienCuoiCung { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? CachThanhToan { get; set; }

    public string? CachVanChuyen { get; set; }

    public int? MaTrangThai { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual TrangThai? MaTrangThaiNavigation { get; set; }
}
