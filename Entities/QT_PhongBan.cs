namespace ASP.NET8.Entities
{
    public class QT_PhongBan
    {
        public int Id_PB { get; set; }
        public string TenPhongBan { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSua { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<QT_NhanVien> QT_NhanViens { get; set; } = new List<QT_NhanVien>();
        public List<QL_PhieuXuat> QT_PhieuXuats { get; set; } = new List<QL_PhieuXuat>();
    }
}
