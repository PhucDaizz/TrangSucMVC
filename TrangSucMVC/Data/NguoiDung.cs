using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class NguoiDung
{
    public string MaNguoiDung { get; set; } = null!;

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public string? VaiTro { get; set; }

    public string? MaNhanVien { get; set; }
}
