using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class KhuyenMai
{
    public string MaKhuyenMai { get; set; } = null!;

    public string? TenKhuyenMai { get; set; }

    public decimal? TiLeChietKhau { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public string? MoTa { get; set; }
}
