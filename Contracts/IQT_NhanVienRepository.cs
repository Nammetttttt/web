using ASP.NET8.Dto;
using ASP.NET8.Entities;

namespace ASP.NET8.Contracts
{
    public interface IQT_NhanVienRepository
    {
        public Task<IEnumerable<QT_NhanVien_HT>> GetQT_NhanVien();
        public Task<QT_NhanVien> GetQT_NhanVien(int Id_NV);
        /*public Task CreateTaiKhoan(TaiKhoanForCreationDto taikhoan);*/
        public Task<QT_NhanVien> CreateQT_NhanVien(QT_NhanVienForCreationDto nhanVien);
        public Task UpdateQT_NhanVien(QT_NhanVienForUpdateDto nhanVien);
        public Task DeleteQT_NhanVien(int Id_NV);
        /*public Task<QT_NhanVien> GetQT_NhanVienByQT_NhanVien_TKid(int id);*/
        /*public Task<List<QT_NhanVien>> GetQT_NhanVienQT_NhanVien_TKMultipleMapping();*/
    }
}
