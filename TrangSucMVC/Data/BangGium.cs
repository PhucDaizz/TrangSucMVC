using System;
using System.Collections.Generic;

namespace TrangSucMVC.Data;

public partial class BangGium
{
    public string MaBangGia { get; set; } = null!;

    public decimal? GiaVang { get; set; }

    public DateTime? ThoiGianCapNhat { get; set; }
}
