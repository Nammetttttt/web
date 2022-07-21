using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQL_PhieuNhapRepository
    {
        public Task<IEnumerable<QL_PhieuNhap_HT>> GetQL_PhieuNhap();
        public Task<QL_PhieuNhap> GetQL_PhieuNhap(int Id_PN);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QL_PhieuNhap> CreateQL_PhieuNhap(QL_PhieuNhapForCreationDto phieuNhap);
        public Task UpdateQL_PhieuNhap(QL_PhieuNhapForUpdateDto phieuNhap);
        public Task DeleteQL_PhieuNhap(int Id_PN);
        /*public Task<QL_PhieuNhap> GetQL_PhieuNhapByQL_PhieuNhap_TKid(int id);*/
        /*public Task<List<QL_PhieuNhap>> GetQL_PhieuNhapQL_PhieuNhap_TKMultipleMapping();*/
    }
}
