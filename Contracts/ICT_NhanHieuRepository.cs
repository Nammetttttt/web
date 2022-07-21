using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface ICT_NhanHieuRepository
    {
        public Task<IEnumerable<CT_NhanHieu>> GetCT_NhanHieu();
        public Task<CT_NhanHieu> GetCT_NhanHieu(int Id_NH);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<CT_NhanHieu> CreateCT_NhanHieu(CT_NhanHieuForCreationDto nhanHieu);
        public Task UpdateCT_NhanHieu(CT_NhanHieuForUpdateDto nhanHieu);
        public Task DeleteCT_NhanHieu(int Id_NH);
        /*public Task<CT_NhanHieu> GetCT_NhanHieuByPQ_NhomQuyen_TKid(int Id_Kho);*/
        /*public Task<List<CT_NhanHieu>> GetCT_NhanHieuPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
