namespace ASP.NET8.Entities
{
    public class QT_NhanVien
    {
        public int Id_NV { get; set; }
        public int Id_PB { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Mail { get; set; }
        public string ChucVu { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<QT_PhongBan> QT_PhongBans { get; set; } = new List<QT_PhongBan>();
        public List<QL_PhieuXuat> QL_PhieuXuats { get; set; } = new List<QL_PhieuXuat>();
        public List<QL_PhieuThuHoi> QL_PhieuThuHoiTSs { get; set; } = new List<QL_PhieuThuHoi>();
        public List<QL_PhieuNhap> QL_PhieuNhaps { get; set; } = new List<QL_PhieuNhap>();
        public List<QL_PhieuThanhLy> QL_PhieuThanhLys { get; set; } = new List<QL_PhieuThanhLy>();
    }
}
