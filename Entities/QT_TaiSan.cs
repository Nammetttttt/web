namespace ASP.NET8.Entities
{
    public class QT_TaiSan
    {
        public int Id_TS { get; set; }
        public string MaTS { get; set; }
        public int Id_PN { get; set; }
        public string TenTS { get; set; }
        public int Id_NH { get; set; }
        public string Ten { get; set; }
        public int Id_Loai { get; set; }
        public string PhanLoai { get; set; }
        public string MoTa { get; set; }
        public string Model { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<CT_NhanHieu> CT_NhanHieus { get; set; } = new List<CT_NhanHieu>();
        public List<CT_ChiTietLoaiTS> CT_ChiTietLoaiTSs { get; set; } = new List<CT_ChiTietLoaiTS>();
        public List<QL_PhieuNhap> QL_PhieuNhaps { get; set; } = new List<QL_PhieuNhap>();


    }
}
