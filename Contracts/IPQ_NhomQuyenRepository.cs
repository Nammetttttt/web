using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IPQ_NhomQuyenRepository
    {
        public Task<IEnumerable<PQ_NhomQuyen>> GetPQ_NhomQuyen();
        public Task<PQ_NhomQuyen> GetPQ_NhomQuyen(int Id_PB);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<PQ_NhomQuyen> CreatePQ_NhomQuyen(PQ_NhomQuyenForCreationDto nhomQuyen);
        public Task UpdatePQ_NhomQuyen(PQ_NhomQuyenForUpdateDto nhomQuyen);
        public Task DeletePQ_NhomQuyen(int Id_PB);
        /*public Task<PQ_NhomQuyen> GetPQ_NhomQuyenByPQ_NhomQuyen_TKid(int id);*/
        /*public Task<List<PQ_NhomQuyen>> GetPQ_NhomQuyenPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
