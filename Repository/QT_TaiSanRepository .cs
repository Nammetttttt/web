using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QT_TaiSanRepository : IQT_TaiSanRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QT_TaiSanRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QT_TaiSan_HT>> GetQT_TaiSan()
        {
            var query = "exec Select_QT_TaiSan_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QT_TaiSan_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QT_TaiSan> GetQT_TaiSan(int Id_TS)
        {
            var query = "exec  selectedtk 18, @Id_TS";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QT_TaiSan>(query, new { Id_TS });

                return company;
            }
        }
        /*public async Task CreateQT_TaiSan(QT_TaiSanForCreationDto taiKhoan)
        {
            var query = "Insert into QT_TaiSan (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QT_TaiSan> CreateQT_TaiSan(QT_TaiSanForCreationDto taiSan)
        {
            var query = "exec  inserted_QT_TaiSan 0, @MaTS,236254,@TenTS,@Ten,@PhanLoai,@MoTa,@Model " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("MaTS", taiSan.MaTS, DbType.String);
            
            parameters.Add("TenTS", taiSan.TenTS, DbType.String);
            parameters.Add("Ten", taiSan.Ten, DbType.String);
            parameters.Add("PhanLoai", taiSan.PhanLoai, DbType.String);
            parameters.Add("MoTa", taiSan.MoTa, DbType.String);
            parameters.Add("Model", taiSan.Model, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QT_TaiSan
                {
                    Id_TS = id,
                    MaTS = taiSan.MaTS,
                    TenTS = taiSan.TenTS,
                    Ten = taiSan.Ten,
                    PhanLoai = taiSan.PhanLoai,
                    MoTa = taiSan.MoTa,
                    Model = taiSan.Model
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
        public async Task UpdateQT_TaiSan(QT_TaiSanForUpdateDto taiSan)
        {
            var query = "exec  inserted_QT_TaiSan  @Id_TS,@MaTS,@SoPhieuNhap,@TenTS,@Ten,@PhanLoai,@MoTa,@Model";

            var parameters = new DynamicParameters();
            parameters.Add("Id_TS", taiSan.Id_TS, DbType.Int32);
            parameters.Add("MaTS", taiSan.MaTS, DbType.String);
            parameters.Add("SoPhieuNhap", taiSan.SoPhieuNhap, DbType.String);
            parameters.Add("TenTS", taiSan.TenTS, DbType.String);
            parameters.Add("Ten", taiSan.Ten, DbType.String);
            parameters.Add("PhanLoai", taiSan.PhanLoai, DbType.String);
            parameters.Add("MoTa", taiSan.MoTa, DbType.String);
            parameters.Add("Model", taiSan.Model, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQT_TaiSan(int Id_TS)
        {
            var query = "exec deleted 18, @Id_TS";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_TS });
            }
        }
        /*public async Task<QT_TaiSan> GetQT_TaiSanByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_QT_TaiSan_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QT_TaiSan>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QT_TaiSan>> GetQT_TaiSanPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_QT_TaiSan_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QT_TaiSan>();

                var companies = await connection.QueryAsync<QT_TaiSan, CT_NhanHieu, QT_TaiSan>(
                    query, (taiSan, nhanHieu) =>
                    {
                        if (!companyDict.TryGetValue(taiSan.Id_TS, out var currentCompany))
                        {
                            currentCompany = taiSan;
                            companyDict.Add(currentCompany.Id_TS, currentCompany);
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
