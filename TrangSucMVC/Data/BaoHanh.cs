using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class BaoHanh
{
    public string MaBaoHanh { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public int? ThoiGianBaoHanh { get; set; }

    public DateOnly? NgayCap { get; set; }
}
