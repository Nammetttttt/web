namespace ASP.NET8.Entities
{
    public class PQ_NhomQuyen_TK
    {
        public int ID { get; set; }
        public int Id_TK { get; set; }
        public int Id_NQ { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }

        public List<PQ_NhomQuyen> PQ_NhomQuyens { get; set; } = new List<PQ_NhomQuyen>();
    }
}
