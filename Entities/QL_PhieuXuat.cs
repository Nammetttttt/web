namespace ASP.NET8.Entities
{
    public class QL_PhieuXuat
    {
        public int Id_PX { get; set; }
        public string SoPhieuXuat { get; set; }
        public DateTime NgayXuat { get; set; }
        public string ViTriSuDung { get; set; }
        
        public int Id_PB { get; set; }
        public string TenPhongBan { get; set; }
        public int Id_NV { get; set; }
        public string TenNV { get; set; }
        public int Id_Kho { get; set; }
        public string MoTa { get; set; }
        public string DienGiai { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<QT_PhongBan> QT_PhongBans { get; set; } = new List<QT_PhongBan>();
        public List<QT_NhanVien> QT_NhanViens { get; set; } = new List<QT_NhanVien>();
        
        public List<CT_Kho> CT_Khos { get; set; } = new List<CT_Kho>();
        public List<PQ_TaiKhoan> PQ_TaiKhoans { get; set; } = new List<PQ_TaiKhoan>();
    }
}
