using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface ICT_KhoRepository
    {
        public Task<IEnumerable<CT_Kho>> GetCT_Kho();
        public Task<CT_Kho> GetCT_Kho(int Id_PB);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<CT_Kho> CreateCT_Kho(CT_KhoForCreationDto kho);
        public Task UpdateCT_Kho(CT_KhoForUpdateDto kho);
        public Task DeleteCT_Kho(int Id_Kho);
        /*public Task<CT_Kho> GetCT_KhoByPQ_NhomQuyen_TKid(int Id_Kho);*/
        /*public Task<List<CT_Kho>> GetCT_KhoPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
