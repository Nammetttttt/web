namespace ASP.NET8.Dto
{
    public class QL_PhieuThanhLyForUpdateDto
    {
        public int Id_PTL { get; set; }
        public string SoPhieuThanhLy { get; set; }
        public DateTime NgayThanhLy { get; set; }
        public string Id_NV { get; set; }

        public string Id_Kho { get; set; }
        public string DienGiai { get; set; }


    }
}
