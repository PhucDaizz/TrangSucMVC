using System.ComponentModel.DataAnnotations;
namespace TrangSucMVC.Views.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "*")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        public string MaKhachHang { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string TenKhachHang { get; set; }

        [MaxLength(24, ErrorMessage = "Tối đa 24 ký tự")]
        [RegularExpression(@"0\d{9}", ErrorMessage = "Chưa đúng định dạng di động Việt Nam")]
		[Display(Name = "Điện thoại")]
		public string SoDienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Chưa đúng định dang Email")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
        public bool GioiTinh { get; set; } = true;

        [Display(Name ="Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [MaxLength(60, ErrorMessage = "Tối đa 60 ký tự")]

        [Display(Name ="Địa chỉ")]
        public string? DiaChi { get; set; }
        public string? Hinh { get; set; } 
        
    }
}
