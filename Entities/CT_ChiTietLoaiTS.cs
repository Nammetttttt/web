namespace ASP.NET8.Entities
{
    public class CT_ChiTietLoaiTS
    {
        public int Id_Loai { get; set; }
        public int NhomLoai { get; set; }
        public string Ten { get; set; }
        public string PhanLoai { get; set; }
        public string MoTa { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<QT_TaiSan> QT_TaiSans { get; set; } = new List<QT_TaiSan>();
    }
}
