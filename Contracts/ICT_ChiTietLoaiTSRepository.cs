using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface ICT_ChiTietLoaiTSRepository
    {
        public Task<IEnumerable<CT_ChiTietLoaiTS>> GetCT_ChiTietLoaiTS();
        public Task<CT_ChiTietLoaiTS> GetCT_ChiTietLoaiTS(int Id_PB);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<CT_ChiTietLoaiTS> CreateCT_ChiTietLoaiTS(CT_ChiTietLoaiTSForCreationDto loaiTS);
        public Task UpdateCT_ChiTietLoaiTS(CT_ChiTietLoaiTSForUpdateDto loaiTS);
        public Task DeleteCT_ChiTietLoaiTS(int Id_Loai);
        /*public Task<CT_ChiTietLoaiTS> GetCT_ChiTietLoaiTSByPQ_NhomQuyen_TKid(int id);*/
        /*public Task<List<CT_ChiTietLoaiTS>> GetCT_ChiTietLoaiTSPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
