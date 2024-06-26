namespace TrangSucMVC.Views.ViewModels
{
    public class CartItem
    {
        public string MaSanPham { get; set; }
        public string Hinh { get; set; }
        public string TenSanPham { get; set; }
        public double GiaBan { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * GiaBan;
    }
}
