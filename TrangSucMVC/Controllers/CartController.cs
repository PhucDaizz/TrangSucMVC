using Microsoft.AspNetCore.Mvc;
using TrangSucMVC.Data;
using TrangSucMVC.Views.ViewModels;
using TrangSucMVC.Helpers;
using Microsoft.AspNetCore.Authorization;
using TrangSucMVC.Services;

namespace TrangSucMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly BanTrangSucContext db;
        private readonly IVnPayService _vnPayservice;
        public CartController(BanTrangSucContext context, IVnPayService vnPayservice)
        {
            db = context;
            _vnPayservice = vnPayservice;
        }
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
        public IActionResult Index()
        {
            return View(Cart);
        }
        public IActionResult AddToCart(string id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaSanPham == id);
            if (item == null)
            {
                var hangHoa = db.SanPhams.SingleOrDefault(p => p.MaSanPham == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    MaSanPham = hangHoa.MaSanPham,
                    TenSanPham = hangHoa.TenSanPham,
                    GiaBan = (double)hangHoa.GiaBan,
                    Hinh = hangHoa.Hinh ?? string.Empty,
                    SoLuong = quantity
                };
                gioHang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }

            HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveCart(string id)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaSanPham == id);
            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
            }
            return RedirectToAction("Index");
        }

		[Authorize]
		[HttpGet]
		public IActionResult Checkout()
		{
			if (Cart.Count == 0)
			{
				return Redirect("/");
			}

			return View(Cart);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Checkout(CheckoutVM model, string payment = "COD")
		{
			if (ModelState.IsValid)
			{
                if (payment == "Thanh toán VNPay")
                {
                    var vnPayModel = new VnPaymentRequestModel
                    {
                        Amount = Cart.Sum(p => p.ThanhTien),
                        CreatedDate = DateTime.Now,
                        Description = $"{model.HoTen} {model.DienThoai}",
                        FullName = model.HoTen,
                        OrderId = new Random().Next(1000, 100000)
                    };
                    return Redirect(_vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel));
                }


                var customerId = HttpContext.User.Claims.SingleOrDefault(p => p.Type == MySetting.CLAIM_CUSTOMERID).Value;
				var khachHang = new KhachHang();
				if (model.GiongKhachHang)
				{
					khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == customerId);
				}

                decimal tongTien = 0;
                foreach (var item in Cart)
                {
                    tongTien += ((decimal?)item.GiaBan ?? 0) * item.SoLuong;
                }

                var hoadon = new HoaDon
				{
                    MaDonHang = Guid.NewGuid().ToString(),
                    MaKhachHang = customerId,
					HoTen = model.HoTen ?? khachHang.TenKhachHang,
					DiaChi = model.DiaChi ?? khachHang.DiaChi,
					DienThoai = model.DienThoai ?? khachHang.SoDienThoai,
					NgayDatHang = DateOnly.FromDateTime(DateTime.Now),
					PhuongThucThanhToan = "COD",
					CachVanChuyen = "GRAB",
					MaTrangThai = 0,
					GhiChu = model.GhiChu,
					TongSoTien = tongTien
				};

				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Add(hoadon);
						db.SaveChanges();

						var cthds = new List<ChiTietHd>();
						foreach (var item in Cart)
						{
							cthds.Add(new ChiTietHd
							{
                                MaCt = Guid.NewGuid().ToString(),
                                MaDonHang = hoadon.MaDonHang,
								SoLuong = item.SoLuong,
								DonGia = (decimal?)item.GiaBan,
								MaSanPham = item.MaSanPham,
								GiamGia = 0
							});
						}
						db.AddRange(cthds);
						db.SaveChanges();
                        db.Database.CommitTransaction();

						

						HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

						return View("Success");
					}
					catch
					{
						db.Database.RollbackTransaction();
					}
				}
			}

			return View(Cart);
		}

        

        [Authorize]
        public IActionResult PaymentSuccess()
        {
            return View("Success");
        }

        [Authorize]
        public IActionResult PaymentFail()
        {
            return View();
        }


        [Authorize]
        public IActionResult PaymentCallBack()
        {
            var response = _vnPayservice.PaymentExecute(Request.Query);

            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }


            // Lưu đơn hàng vô database

            TempData["Message"] = $"Thanh toán VNPay thành công";
            return RedirectToAction("PaymentSuccess");
        }
    }
}