namespace TrangSucMVC.Views.ViewModels
{
    public class SanPhamVM
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Hinh { get; set; }
        public decimal GiaBan { get; set; }
        public int ThoiGianBaoHanh { get; set;}
        public string LoaiSanPham { get; set;}
        public decimal? GiamGia { get; set; }

    }

    public class ChiTietSanPhamVM
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Hinh { get; set; }
        public decimal GiaBan { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public string LoaiSanPham { get; set; }
        public string ChiTiet {  get; set; }
        public int DiemDanhGia {  get; set; }
        public int SoLuongTon {  get; set; }
           

    }
}
