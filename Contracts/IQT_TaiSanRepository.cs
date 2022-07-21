using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQT_TaiSanRepository
    {
        public Task<IEnumerable<QT_TaiSan_HT>> GetQT_TaiSan();
        public Task<QT_TaiSan> GetQT_TaiSan(int Id_TS);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QT_TaiSan> CreateQT_TaiSan(QT_TaiSanForCreationDto taiSan);
        public Task UpdateQT_TaiSan(QT_TaiSanForUpdateDto taiSan);
        public Task DeleteQT_TaiSan(int Id_TS);
        /*public Task<QT_TaiSan> GetQT_TaiSanByPQ_NhomQuyen_TKid(int id);
        public Task<List<QT_TaiSan>> GetQT_TaiSanPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
