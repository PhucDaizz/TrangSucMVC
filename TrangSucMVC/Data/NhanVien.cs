using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public string? ChucVu { get; set; }

    public decimal? Luong { get; set; }

    public decimal? HieuSuatBanHang { get; set; }

    public string? QuayLamViec { get; set; }
}
