using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QT_PhongBanRepository : IQT_PhongBanRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QT_PhongBanRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QT_PhongBan>> GetQT_PhongBan()
        {
            var query = "exec  selected 17";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QT_PhongBan>(query);
                return compan.ToList();
            }
        }
        public async Task<QT_PhongBan> GetQT_PhongBan(int Id_PB)
        {
            var query = "exec  selectedtk 17, @Id_PB";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QT_PhongBan>(query, new { Id_PB });

                return company;
            }
        }
        /*public async Task CreateQT_PhongBan(QT_PhongBanForCreationDto taiKhoan)
        {
            var query = "Insert into QT_PhongBan (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QT_PhongBan> CreateQT_PhongBan(QT_PhongBanForCreationDto phongBan)
        {
            var query = "exec  inserted_QT_PhongBan 0, @TenPhongBan " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("TenPhongBan", phongBan.TenPhongBan, DbType.String);
            

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QT_PhongBan
                {
                    Id_PB = id,
                    TenPhongBan = phongBan.TenPhongBan
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
        public async Task UpdateQT_PhongBan(QT_PhongBanForUpdateDto phongBan)
        {
            var query = "exec  inserted_QT_PhongBan @Id_PB, @TenPhongBan ";

            var parameters = new DynamicParameters();
            parameters.Add("Id_PB", phongBan.Id_PB, DbType.Int32);
            parameters.Add("TenPhongBan", phongBan.TenPhongBan, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQT_PhongBan(int Id_PB)
        {
            var query = "exec deleted 17, @Id_PB";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PB });
            }
        }
        /*public async Task<QT_PhongBan> GetQT_PhongBanByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_QT_PhongBan_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QT_PhongBan>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }*/
        /*public async Task<List<QT_PhongBan>> GetQT_PhongBanPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_QT_PhongBan_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QT_PhongBan>();

                var companies = await connection.QueryAsync<QT_PhongBan, CT_NhanHieu, QT_PhongBan>(
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
