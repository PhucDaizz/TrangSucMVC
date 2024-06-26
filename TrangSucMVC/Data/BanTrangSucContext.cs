using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrangSucMVC.Data;

public partial class BanTrangSucContext : DbContext
{
    public BanTrangSucContext()
    {
    }

    public BanTrangSucContext(DbContextOptions<BanTrangSucContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangGium> BangGia { get; set; }

    public virtual DbSet<BaoHanh> BaoHanhs { get; set; }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<ChinhSachDoiTra> ChinhSachDoiTras { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<HieuSuat> HieuSuats { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<MuaLai> MuaLais { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TrangThai> TrangThais { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=PHUCDAI-LAPTOP\\SQLEXPRESS;Initial Catalog=BanTrangSuc;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangGium>(entity =>
        {
            entity.HasKey(e => e.MaBangGia).HasName("PK__BangGia__5DAC5A68D2656906");

            entity.Property(e => e.MaBangGia).HasMaxLength(50);
            entity.Property(e => e.GiaVang).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThoiGianCapNhat).HasColumnType("datetime");
        });

        modelBuilder.Entity<BaoHanh>(entity =>
        {
            entity.HasKey(e => e.MaBaoHanh).HasName("PK__BaoHanh__A8DF52E5E6E96379");

            entity.ToTable("BaoHanh");

            entity.Property(e => e.MaBaoHanh).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);
        });

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => e.MaCt);

            entity.ToTable("ChiTietHd");

            entity.Property(e => e.MaCt)
                .HasMaxLength(50)
                .HasColumnName("MaCT");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiamGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaDonHang).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK_ChiTietHd_HoaDon");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK_ChiTietHd_SanPham");
        });

        modelBuilder.Entity<ChinhSachDoiTra>(entity =>
        {
            entity.HasKey(e => e.MaChinhSach).HasName("PK__ChinhSac__82663E30066B564D");

            entity.ToTable("ChinhSachDoiTra");

            entity.Property(e => e.MaChinhSach).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenChinhSach).HasMaxLength(100);
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__DonHang__129584ADA0D3C87F");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaDonHang).HasMaxLength(50);
            entity.Property(e => e.ChietKhau).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.SoTienCuoiCung).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongSoTien).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<HieuSuat>(entity =>
        {
            entity.HasKey(e => e.MaHieuSuat).HasName("PK__HieuSuat__1DFCDC12052BF1FC");

            entity.ToTable("HieuSuat");

            entity.Property(e => e.MaHieuSuat).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.MaQuay).HasMaxLength(50);
            entity.Property(e => e.TongDoanhThu).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaDonHang);

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaDonHang).HasMaxLength(50);
            entity.Property(e => e.CachThanhToan).HasMaxLength(50);
            entity.Property(e => e.CachVanChuyen).HasMaxLength(50);
            entity.Property(e => e.ChietKhau).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.SoTienCuoiCung).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongSoTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_HoaDon_KhachHang");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK_HoaDon_TrangThai");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E581D6479B");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.RandomKey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKhuyenMai).HasName("PK__KhuyenMa__6F56B3BD1D3510BE");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKhuyenMai).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenKhuyenMai).HasMaxLength(100);
            entity.Property(e => e.TiLeChietKhau).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<MuaLai>(entity =>
        {
            entity.HasKey(e => e.MaMuaLai).HasName("PK__MuaLai__0A2EB377DE398F6E");

            entity.ToTable("MuaLai");

            entity.Property(e => e.MaMuaLai).HasMaxLength(50);
            entity.Property(e => e.GiaMuaLai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D762558FA462");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.MaNguoiDung).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.VaiTro).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47EF4C67EB");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.HieuSuatBanHang).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Luong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.QuayLamViec).HasMaxLength(100);
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D4E6A6F88");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiaVangTaiThoiDiem).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.LoaiSanPham).HasMaxLength(100);
            entity.Property(e => e.TenSanPham).HasMaxLength(100);
            entity.Property(e => e.TienCong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienDa).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrongLuong).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TrangThai>(entity =>
        {
            entity.HasKey(e => e.MaTrangThai);

            entity.ToTable("TrangThai");

            entity.Property(e => e.MaTrangThai).ValueGeneratedNever();
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenTrangThai).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
