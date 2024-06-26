using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class HieuSuat
{
    public string MaHieuSuat { get; set; } = null!;

    public string? MaNhanVien { get; set; }

    public string? MaQuay { get; set; }

    public decimal? TongDoanhThu { get; set; }

    public DateOnly? Ngay { get; set; }
}
