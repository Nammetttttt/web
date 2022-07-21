using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IPQ_NhomQuyen_TKRepository
    {
        public Task<IEnumerable<PQ_NhomQuyen_TK_HT>> GetPQ_NhomQuyen_TK();
        public Task<PQ_NhomQuyen_TK> GetPQ_NhomQuyen_TK(int ID);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<PQ_NhomQuyen_TK> CreatePQ_NhomQuyen_TK(PQ_NhomQuyen_TKForCreationDto NQ_taiKhoan);
        public Task UpdatePQ_NhomQuyen_TK(PQ_NhomQuyen_TKForUpdateDto NQ_taiKhoan);
        public Task DeletePQ_NhomQuyen_TK(int Id_NQ);
        /*public Task<PQ_NhomQuyen_TK> GetPQ_NhomQuyen_TKByPQ_NhomQuyen_TK_TKid(int id);*/
        /*public Task<List<PQ_NhomQuyen_TK>> GetPQ_NhomQuyen_TKPQ_NhomQuyen_TK_TKMultipleMapping();*/
    }
}
