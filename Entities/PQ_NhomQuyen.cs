namespace ASP.NET8.Entities
{
    public class PQ_NhomQuyen
    {
        public int Id_NQ { get; set; }
        public string Ten { get; set; }
        public string NgayKhoiTao { get; set; }
        public string TKKhoiTao { get; set; }
        public string NgayChinhSuaGanNhat { get; set; }
        public string TKChinhSua { get; set; }
        public string MucDaXoa { get; set; }
        public List<PQ_NhomQuyen_TK> PQ_NhomQuyen_TKs { get; set; } = new List<PQ_NhomQuyen_TK>();
        public List<PQ_NhomQuyen_CN> PQ_NhomQuyen_CNs { get; set; } = new List<PQ_NhomQuyen_CN>();
    }
}
