using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class MuaLai
{
    public string MaMuaLai { get; set; } = null!;

    public string? MaKhachHang { get; set; }

    public string? MaSanPham { get; set; }

    public decimal? GiaMuaLai { get; set; }

    public DateOnly? NgayMuaLai { get; set; }

    public string? MaNhanVien { get; set; }
}
