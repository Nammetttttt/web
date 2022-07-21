using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IPQ_TaiKhoanRepository
    {
        public Task<IEnumerable<PQ_TaiKhoan_HT>> GetPQ_TaiKhoan();
        public Task<PQ_TaiKhoan> GetPQ_TaiKhoan(int Id_TK);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<PQ_TaiKhoan> CreatePQ_TaiKhoan(PQ_TaiKhoanForCreationDto taiKhoan);
        public Task UpdatePQ_TaiKhoan(PQ_TaiKhoanForUpdateDto taiKhoan);
        public Task DeletePQ_TaiKhoan(int Id_TK);
        /*public Task<PQ_TaiKhoan> GetPQ_TaiKhoanByPQ_NhomQuyen_TKid(int id);
        public Task<List<PQ_TaiKhoan>> GetPQ_TaiKhoanPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
