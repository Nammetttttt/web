using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class CT_NhanHieuRepository : ICT_NhanHieuRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public CT_NhanHieuRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CT_NhanHieu>> GetCT_NhanHieu()
        {
            var query = "exec  selected 3";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<CT_NhanHieu>(query);
                return compan.ToList();
            }
        }
        public async Task<CT_NhanHieu> GetCT_NhanHieu(int Id_NH)
        {
            var query = "exec  selectedtk 3, @Id_NH";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<CT_NhanHieu>(query, new { Id_NH });

                return company;
            }
        }
        /*public async Task CreateCT_NhanHieu(CT_NhanHieuForCreationDto taiKhoan)
        {
            var query = "Insert into CT_NhanHieu (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<CT_NhanHieu> CreateCT_NhanHieu(CT_NhanHieuForCreationDto nhanHieu)
        {
            var query = "exec  inserted_CT_NhanHieu 0, @Ten " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Ten", nhanHieu.Ten, DbType.String);
            

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new CT_NhanHieu
                {
                    Id_NH = id,
                    Ten = nhanHieu.Ten
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
        public async Task UpdateCT_NhanHieu(CT_NhanHieuForUpdateDto nhanHieu)
        {
            var query = "exec  inserted_CT_NhanHieu @Id_NH,@Ten";

            var parameters = new DynamicParameters();
            parameters.Add("Id_NH", nhanHieu.Id_NH, DbType.Int32);
            parameters.Add("Ten", nhanHieu.Ten, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCT_NhanHieu(int Id_NH)
        {
            var query = "exec deleted 3, @Id_NH";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_NH });
            }
        }
        /*public async Task<CT_NhanHieu> GetCT_NhanHieuByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_CT_NhanHieu_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<CT_NhanHieu>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }*/
        /*public async Task<List<CT_NhanHieu>> GetCT_NhanHieuPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_CT_NhanHieu_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, CT_NhanHieu>();

                var companies = await connection.QueryAsync<CT_NhanHieu, CT_NhanHieu, CT_NhanHieu>(
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
