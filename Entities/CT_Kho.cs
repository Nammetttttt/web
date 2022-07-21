namespace ASP.NET8.Entities
{
    public class CT_Kho
    {
        public int Id_Kho { get; set; }
        public string MoTa { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<QL_PhieuXuat> QL_PhieuXuats { get; set; } = new List<QL_PhieuXuat>();
        public List<QL_PhieuThuHoi> QL_PhieuThuHoiTSs { get; set; } = new List<QL_PhieuThuHoi>();
        public List<QL_PhieuNhap> QL_PhieuNhaps { get; set; } = new List<QL_PhieuNhap>();
        public List<QL_PhieuThanhLy> QL_PhieuThanhLys { get; set; } = new List<QL_PhieuThanhLy>();
    }
}
