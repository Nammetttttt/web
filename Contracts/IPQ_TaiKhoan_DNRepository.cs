using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IPQ_TaiKhoan_DNRepository
    {
        /*public Task<IEnumerable<PQ_TaiKhoan_DN>> GetPQ_TaiKhoan_DN();*/
        public Task<PQ_TaiKhoan_DN> GetPQ_TaiKhoan_DN(PQ_TaiKhoan_DNForCreationDto nguoidung);
        public Task<PQ_TaiKhoan_DN> GetPQ_TaiKhoan_DN1(PQ_TaiKhoan_DNForCreationDto nguoidung);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        /*public Task<PQ_TaiKhoan_DN_DN> CreatePQ_TaiKhoan_DN_DN(PQ_TaiKhoan_DN_DNForCreationDto taiKhoan);
        public Task UpdatePQ_TaiKhoan_DN(int Id_TK, PQ_TaiKhoan_DN_DNForUpdateDto taiKhoan);
        public Task DeletePQ_TaiKhoan_DN(int Id_TK);*/
        /*public Task<PQ_TaiKhoan_DN> GetPQ_TaiKhoan_DN_DNByPQ_NhomQuyen_TKid(int id);
        public Task<List<PQ_TaiKhoan_DN>> GetPQ_TaiKhoan_DNPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
