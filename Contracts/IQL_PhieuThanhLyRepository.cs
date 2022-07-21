using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQL_PhieuThanhLyRepository
    {
        public Task<IEnumerable<QL_PhieuThanhLy_HT>> GetQL_PhieuThanhLy();
        public Task<QL_PhieuThanhLy> GetQL_PhieuThanhLy(int Id_PTL);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QL_PhieuThanhLy> CreateQL_PhieuThanhLy(QL_PhieuThanhLyForCreationDto phieuThanhly);
        public Task UpdateQL_PhieuThanhLy(QL_PhieuThanhLyForUpdateDto phieuThanhly);
        public Task DeleteQL_PhieuThanhLy(int Id_PTL);
        /*public Task<QL_PhieuThanhLy> GetQL_PhieuThanhLyByQL_PhieuThanhLy_TKid(int id);*/
        /*public Task<List<QL_PhieuThanhLy>> GetQL_PhieuThanhLyQL_PhieuThanhLy_TKMultipleMapping();*/
    }
}
