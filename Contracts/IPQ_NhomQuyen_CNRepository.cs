using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IPQ_NhomQuyen_CNRepository
    {
        public Task<IEnumerable<PQ_NhomQuyen_CN_HT>> GetPQ_NhomQuyen_CN();
        public Task<PQ_NhomQuyen_CN> GetPQ_NhomQuyen_CN(int Id_NQ);
        public Task<PQ_NhomQuyen_CN> GetPQ_NhomQuyen_CN_(int ID);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<PQ_NhomQuyen_CN> CreatePQ_NhomQuyen_CN(PQ_NhomQuyen_CNForCreationDto NQ_chucNang);
        public Task UpdatePQ_NhomQuyen_CN(PQ_NhomQuyen_CNForUpdateDto NQ_chucNang);
        public Task DeletePQ_NhomQuyen_CN(int Id_NQ);
        /*public Task<PQ_NhomQuyen_CN> GetPQ_NhomQuyen_CNByPQ_NhomQuyen_CN_TKid(int id);*/
        /*public Task<List<PQ_NhomQuyen_CN>> GetPQ_NhomQuyen_CNPQ_NhomQuyen_CN_TKMultipleMapping();*/
    }
}
