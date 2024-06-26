using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string? TenKhachHang { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public int? DiemTichLuy { get; set; }

    public string? MatKhau { get; set; }

    public bool? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Hinh { get; set; }

    public bool? HieuLuc { get; set; }

    public int? VaiTro { get; set; }

    public string? RandomKey { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
