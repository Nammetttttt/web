using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQL_PhieuThanhLy_ChiTietRepository
    {
        public Task<IEnumerable<QL_PhieuThanhLy_ChiTiet_HT>> GetQL_PhieuThanhLy_ChiTiet();
        public Task<QL_PhieuThanhLy_ChiTiet> GetQL_PhieuThanhLy_ChiTiet(int ID);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QL_PhieuThanhLy_ChiTiet> CreateQL_PhieuThanhLy_ChiTiet(QL_PhieuThanhLy_ChiTietForCreationDto phieuThanhlyct);
        public Task UpdateQL_PhieuThanhLy_ChiTiet(QL_PhieuThanhLy_ChiTietForUpdateDto phieuThanhlyct);
        public Task DeleteQL_PhieuThanhLy_ChiTiet(int Id_PTL);
        /*public Task<QL_PhieuThanhLy_ChiTiet> GetQL_PhieuThanhLy_ChiTietByQL_PhieuThanhLy_ChiTiet_TKid(int id);*/
        /*public Task<List<QL_PhieuThanhLy_ChiTiet>> GetQL_PhieuThanhLy_ChiTietQL_PhieuThanhLy_ChiTiet_TKMultipleMapping();*/
    }
}
