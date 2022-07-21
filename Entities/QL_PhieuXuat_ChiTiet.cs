namespace ASP.NET8.Entities
{
    public class QL_PhieuXuat_ChiTiet
    {
        public int ID { get; set; }
        public int Id_PX { get; set; }
        public int Id_TS { get; set; }
        public string TenTS { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<QL_PhieuXuat> QL_PhieuXuats { get; set; } = new List<QL_PhieuXuat>();
    }
}
