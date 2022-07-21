using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QT_NhanVienRepository : IQT_NhanVienRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QT_NhanVienRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QT_NhanVien_HT>> GetQT_NhanVien()
        {
            var query = "exec Select_QT_NhanVien_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QT_NhanVien_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QT_NhanVien> GetQT_NhanVien(int Id_NV)
        {
            var query = "exec  selectedtk 16, @Id_NV";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QT_NhanVien>(query, new { Id_NV });

                return company;
            }
        }
        /*public async Task CreateQT_NhanVien(QT_NhanVienForCreationDto taiKhoan)
        {
            var query = "Insert into QT_NhanVien (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QT_NhanVien> CreateQT_NhanVien(QT_NhanVienForCreationDto nhanVien)
        {
            var query = "exec inserted_QT_NhanVien 0,@Id_PB,@TenNV,@NgaySinh,@SDT,@Mail,@ChucVu " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Id_PB", nhanVien.Id_PB, DbType.String);
            parameters.Add("TenNV", nhanVien.TenNV, DbType.String);
            parameters.Add("NgaySinh", nhanVien.NgaySinh, DbType.String);
            parameters.Add("SDT", nhanVien.SDT, DbType.String);
            parameters.Add("Mail", nhanVien.Mail, DbType.String);
            parameters.Add("ChucVu", nhanVien.ChucVu, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QT_NhanVien
                {
                    Id_NV = id,
                    
                    TenNV = nhanVien.TenNV,
                   
                    SDT = nhanVien.SDT,
                    Mail = nhanVien.Mail,
                    ChucVu = nhanVien.ChucVu,
                };

                return createdTaiKhoan;
            }
            /*DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLTS");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
                return new JsonResult(table);
            }*/
        }
        public async Task UpdateQT_NhanVien(QT_NhanVienForUpdateDto nhanVien)
        {
            var query = "exec  inserted_QT_NhanVien @Id_NV,@Id_PB,@TenNV,@NgaySinh,@SDT,@Mail,@ChucVu";

            var parameters = new DynamicParameters();
            parameters.Add("Id_NV", nhanVien.Id_NV, DbType.Int32);
            
            parameters.Add("Id_PB", nhanVien.Id_PB, DbType.String);
            parameters.Add("TenNV", nhanVien.TenNV, DbType.String);
            parameters.Add("NgaySinh", nhanVien.NgaySinh, DbType.String);
            parameters.Add("SDT", nhanVien.SDT, DbType.String);
            parameters.Add("Mail", nhanVien.Mail, DbType.String);
            parameters.Add("ChucVu", nhanVien.ChucVu, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQT_NhanVien(int Id_NV)
        {
            var query = "exec deleted 16, @Id_NV";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_NV });
            }
        }
        /*public async Task<QT_NhanVien> GetQT_NhanVienByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_QT_NhanVien_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QT_NhanVien>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }*/
        /*public async Task<List<QT_NhanVien>> GetQT_NhanVienPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_QT_NhanVien_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QT_NhanVien>();

                var companies = await connection.QueryAsync<QT_NhanVien, CT_NhanHieu, QT_NhanVien>(
                    query, (phongBan, nhanHieu) =>
                    {
                        if (!companyDict.TryGetValue(phongBan.Id_PB, out var currentCompany))
                        {
                            currentCompany = phongBan;
                            companyDict.Add(currentCompany.Id_PB, currentCompany);
                        }

                        currentCompany.CT_NhanHieus.Add(nhanHieu);
                        return currentCompany;
                    }

                );

                return companies.Distinct().ToList();
            }
        }*/

    }
}
