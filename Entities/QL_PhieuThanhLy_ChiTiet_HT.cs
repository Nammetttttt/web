namespace ASP.NET8.Entities
{
    public class QL_PhieuThanhLy_ChiTiet_HT
    {
        public int ID { get; set; }
        public int Id_PTL { get; set; }
        public string SoPhieuThanhLy { get; set; }
        public int Id_TS { get; set; }
        public string TenTS { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<QL_PhieuThanhLy> QL_PhieuThanhLys { get; set; } = new List<QL_PhieuThanhLy>();
    }
}
