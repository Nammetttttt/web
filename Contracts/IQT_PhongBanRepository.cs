using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQT_PhongBanRepository
    {
        public Task<IEnumerable<QT_PhongBan>> GetQT_PhongBan();
        public Task<QT_PhongBan> GetQT_PhongBan(int Id_PB);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QT_PhongBan> CreateQT_PhongBan(QT_PhongBanForCreationDto phongBan);
        public Task UpdateQT_PhongBan(QT_PhongBanForUpdateDto phongBan);
        public Task DeleteQT_PhongBan(int Id_PB);
        /*public Task<QT_PhongBan> GetQT_PhongBanByPQ_NhomQuyen_TKid(int id);*/
        /*public Task<List<QT_PhongBan>> GetQT_PhongBanPQ_NhomQuyen_TKMultipleMapping();*/
    }
}
