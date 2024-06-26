using AutoMapper;
using TrangSucMVC.Data;
using TrangSucMVC.Views.ViewModels;

namespace TrangSucMVC.Helpers
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile() 
		{
			CreateMap<RegisterVM, KhachHang>();
				//.ForMember(kh => kh.TenKhachHang, option => option.MapFrom(RegisterVM => RegisterVM.TenKhachHang)).ReverseMap();
				
		}
	}
}
