using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQL_PhieuThuHoiRepository
    {
        public Task<IEnumerable<QL_PhieuThuHoi_HT>> GetQL_PhieuThuHoi();
        public Task<QL_PhieuThuHoi> GetQL_PhieuThuHoi(int Id_PTH);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QL_PhieuThuHoi> CreateQL_PhieuThuHoi(QL_PhieuThuHoiForCreationDto phieuThuhoi);
        public Task UpdateQL_PhieuThuHoi(QL_PhieuThuHoiForUpdateDto phieuThuhoi);
        public Task DeleteQL_PhieuThuHoi(int Id_PTH);
        /*public Task<QL_PhieuThuHoi> GetQL_PhieuThuHoiByQL_PhieuThuHoi_TKid(int id);*/
        /*public Task<List<QL_PhieuThuHoi>> GetQL_PhieuThuHoiQL_PhieuThuHoi_TKMultipleMapping();*/
    }
}
