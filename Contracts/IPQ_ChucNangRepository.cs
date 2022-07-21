using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IPQ_ChucNangRepository
    {
        public Task<IEnumerable<PQ_ChucNang>> GetPQ_ChucNang();
        public Task<PQ_ChucNang> GetPQ_ChucNang(int Id_CN);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<PQ_ChucNang> CreatePQ_ChucNang(PQ_ChucNangForCreationDto chucNang);
        public Task UpdatePQ_ChucNang(PQ_ChucNangForUpdateDto chucNang);
        public Task DeletePQ_ChucNang(int Id_CN);
        /*public Task<PQ_ChucNang> GetPQ_ChucNangByPQ_ChucNang_TKid(int id);*/
        /*public Task<List<PQ_ChucNang>> GetPQ_ChucNangPQ_ChucNang_TKMultipleMapping();*/
    }
}
