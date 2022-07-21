namespace ASP.NET8.Entities
{
    public class PQ_NhomQuyen_CN
    {
        public int ID { get; set; }
        public int Id_CN { get; set; }
        public int Id_NQ { get; set; }
        public int Xem { get; set; }
        public int Them { get; set; }
        public int Sua { get; set; }
        public int Xoa { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<PQ_NhomQuyen> PQ_NhomQuyens { get; set; } = new List<PQ_NhomQuyen>();
        public List<PQ_ChucNang> PQ_ChucNangs { get; set; } = new List<PQ_ChucNang>();
    }
}
