using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class CT_KhoRepository : ICT_KhoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public CT_KhoRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CT_Kho>> GetCT_Kho()
        {
            var query = "exec selected 2";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<CT_Kho>(query);
                return compan.ToList();
            }
        }
        public async Task<CT_Kho> GetCT_Kho(int Id_Kho)
        {
            var query = "exec selectedtk 2, @Id_Kho";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<CT_Kho>(query, new { Id_Kho });

                return company;
            }
        }
        /*public async Task CreateCT_Kho(CT_KhoForCreationDto taiKhoan)
        {
            var query = "Insert into CT_Kho (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<CT_Kho> CreateCT_Kho(CT_KhoForCreationDto kho)
        {
            var query = "exec  inserted_CT_Kho 0, @MoTa " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("MoTa", kho.MoTa, DbType.String);
            

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new CT_Kho
                {
                    Id_Kho = id,
                    MoTa = kho.MoTa
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
        public async Task UpdateCT_Kho(CT_KhoForUpdateDto kho)
        {
            var query = "exec  inserted_CT_Kho @Id_Kho,@MoTa";

            var parameters = new DynamicParameters();
            parameters.Add("Id_Kho", kho.Id_Kho, DbType.Int32);
            parameters.Add("MoTa", kho.MoTa, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCT_Kho(int Id_Kho)
        {
            var query = "exec deleted 2, @Id_Kho";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_Kho });
            }
        }
        /*public async Task<CT_Kho> GetCT_KhoByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_CT_Kho_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<CT_Kho>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }*/
        /*public async Task<List<CT_Kho>> GetCT_KhoPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_CT_Kho_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, CT_Kho>();

                var companies = await connection.QueryAsync<CT_Kho, CT_NhanHieu, CT_Kho>(
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
