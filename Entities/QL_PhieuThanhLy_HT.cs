namespace ASP.NET8.Entities
{
    public class QL_PhieuThanhLy_HT
    {
        public int Id_PTL { get; set; }
        public string SoPhieuThanhLy { get; set; }
        public DateTime NgayThanhLy { get; set; }
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
        public List<QT_NhanVien> QT_NhanViens { get; set; } = new List<QT_NhanVien>();
        public List<CT_Kho> CT_Khos { get; set; } = new List<CT_Kho>();
    }
}
