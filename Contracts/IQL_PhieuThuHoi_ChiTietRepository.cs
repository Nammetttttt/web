using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQL_PhieuThuHoi_ChiTietRepository
    {
        public Task<IEnumerable<QL_PhieuThuHoi_ChiTiet_HT>> GetQL_PhieuThuHoi_ChiTiet();
        public Task<QL_PhieuThuHoi_ChiTiet> GetQL_PhieuThuHoi_ChiTiet(int ID);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QL_PhieuThuHoi_ChiTiet> CreateQL_PhieuThuHoi_ChiTiet(QL_PhieuThuHoi_ChiTietForCreationDto phieuThuhoict);
        public Task UpdateQL_PhieuThuHoi_ChiTiet(QL_PhieuThuHoi_ChiTietForUpdateDto phieuThuhoict);
        public Task DeleteQL_PhieuThuHoi_ChiTiet(int Id_PTH);
        /*public Task<QL_PhieuThuHoi_ChiTiet> GetQL_PhieuThuHoi_ChiTietByQL_PhieuThuHoi_ChiTiet_TKid(int id);*/
        /*public Task<List<QL_PhieuThuHoi_ChiTiet>> GetQL_PhieuThuHoi_ChiTietQL_PhieuThuHoi_ChiTiet_TKMultipleMapping();*/
    }
}
