using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQL_PhieuXuatRepository
    {
        public Task<IEnumerable<QL_PhieuXuat_HT>> GetQL_PhieuXuat();
        public Task<QL_PhieuXuat> GetQL_PhieuXuat(int Id_PX);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QL_PhieuXuat> CreateQL_PhieuXuat(QL_PhieuXuatForCreationDto phieuXuat);
        public Task UpdateQL_PhieuXuat(QL_PhieuXuatForUpdateDto phieuXuat);
        public Task DeleteQL_PhieuXuat(int Id_PX);
        /*public Task<QL_PhieuXuat> GetQL_PhieuXuatByQL_PhieuXuat_TKid(int id);*/
        /*public Task<List<QL_PhieuXuat>> GetQL_PhieuXuatQL_PhieuXuat_TKMultipleMapping();*/
    }
}
