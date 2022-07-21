using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class PQ_NhomQuyen_TKRepository : IPQ_NhomQuyen_TKRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public PQ_NhomQuyen_TKRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PQ_NhomQuyen_TK_HT>> GetPQ_NhomQuyen_TK()
        {
            var query = "exec Select_PQ_NhomQuyen_TK_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<PQ_NhomQuyen_TK_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<PQ_NhomQuyen_TK> GetPQ_NhomQuyen_TK(int ID)
        {
            var query = "exec  selectedtk 7, @ID";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_NhomQuyen_TK>(query, new { ID });

                return company;
            }
        }
        /*public async Task CreatePQ_NhomQuyen_TK(PQ_NhomQuyen_TKForCreationDto taiKhoan)
        {
            var query = "Insert into PQ_NhomQuyen_TK (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<PQ_NhomQuyen_TK> CreatePQ_NhomQuyen_TK(PQ_NhomQuyen_TKForCreationDto NQ_taiKhoan)
        {
            var query = "exec  inserted_PQ_NhomQuyen_TK 0, @Id_TK,@Id_NQ " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Id_TK", NQ_taiKhoan.Id_TK, DbType.Int32);
            parameters.Add("Id_NQ", NQ_taiKhoan.Id_NQ, DbType.Int32);
            


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new PQ_NhomQuyen_TK
                {
                    ID = id,
                    Id_TK = NQ_taiKhoan.Id_TK,
                    Id_NQ = NQ_taiKhoan.Id_NQ,
                    

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
        public async Task UpdatePQ_NhomQuyen_TK(PQ_NhomQuyen_TKForUpdateDto NQ_taiKhoan)
        {
            var query = "exec  inserted_PQ_NhomQuyen_TK @ID,@Id_TK,@Id_NQ";

            var parameters = new DynamicParameters();
            parameters.Add("ID", NQ_taiKhoan.ID, DbType.Int32);
            parameters.Add("Id_TK", NQ_taiKhoan.Id_TK, DbType.Int32);
            parameters.Add("Id_NQ", NQ_taiKhoan.Id_NQ, DbType.Int32);
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePQ_NhomQuyen_TK(int Id_NQ)
        {
            var query = "exec deleted 7, @Id_NQ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_NQ });
            }
        }
        /*public async Task<PQ_NhomQuyen_TK> GetPQ_NhomQuyen_TKByPQ_NhomQuyen_TK_TKid(int id)
        {
            var procedureName = "select_PQ_NhomQuyen_TK_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<PQ_NhomQuyen_TK>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<PQ_NhomQuyen_TK>> GetPQ_NhomQuyen_TKPQ_NhomQuyen_TK_TKMultipleMapping()
        {
            var query = "select_PQ_NhomQuyen_TK_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, PQ_NhomQuyen_TK>();

                var companies = await connection.QueryAsync<PQ_NhomQuyen_TK, CT_NhanHieu, PQ_NhomQuyen_TK>(
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
