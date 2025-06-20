using System.ComponentModel.DataAnnotations;
namespace WebApiUsingEntityFrameworkCore.Models
{
    public class SanPham
    {
        private int _MaSanPham;
        private string _TenSanPham;
        private double _GiaBan;

        [Key]
        public int MaSanPham { get => _MaSanPham; set => _MaSanPham = value; }
        public string TenSanPham { get => _TenSanPham; set => _TenSanPham = value; }
        public double GiaBan { get => _GiaBan; set => _GiaBan = value; }

        public SanPham(int maSanPham, string tenSanPham, double giaBan)
        {
            _MaSanPham = maSanPham;
            _TenSanPham = tenSanPham;
            _GiaBan = giaBan;
        }
        public SanPham()
        {
            _MaSanPham = 0;
            _TenSanPham = string.Empty;
            _GiaBan = 0.0f;
        }
    }
}
