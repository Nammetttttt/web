using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQL_PhieuXuat_ChiTietRepository
    {
        public Task<IEnumerable<QL_PhieuXuat_ChiTiet_HT>> GetQL_PhieuXuat_ChiTiet();
        public Task<QL_PhieuXuat_ChiTiet> GetQL_PhieuXuat_ChiTiet(int ID);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QL_PhieuXuat_ChiTiet> CreateQL_PhieuXuat_ChiTiet(QL_PhieuXuat_ChiTietForCreationDto phieuThuhoict);
        public Task UpdateQL_PhieuXuat_ChiTiet(QL_PhieuXuat_ChiTietForUpdateDto phieuThuhoict);
        public Task DeleteQL_PhieuXuat_ChiTiet(int Id_PX);
        /*public Task<QL_PhieuXuat_ChiTiet> GetQL_PhieuXuat_ChiTietByQL_PhieuXuat_ChiTiet_TKid(int id);*/
        /*public Task<List<QL_PhieuXuat_ChiTiet>> GetQL_PhieuXuat_ChiTietQL_PhieuXuat_ChiTiet_TKMultipleMapping();*/
    }
}
