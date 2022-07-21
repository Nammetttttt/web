using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class PQ_NhomQuyenRepository : IPQ_NhomQuyenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public PQ_NhomQuyenRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PQ_NhomQuyen>> GetPQ_NhomQuyen()
        {
            var query = "exec  selected 5";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<PQ_NhomQuyen>(query);
                return compan.ToList();
            }
        }
        public async Task<PQ_NhomQuyen> GetPQ_NhomQuyen(int Id_NQ)
        {
            var query = "exec  selectedtk 5, @Id_NQ";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_NhomQuyen>(query, new { Id_NQ });

                return company;
            }
        }
        /*public async Task CreatePQ_NhomQuyen(PQ_NhomQuyenForCreationDto taiKhoan)
        {
            var query = "Insert into PQ_NhomQuyen (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<PQ_NhomQuyen> CreatePQ_NhomQuyen(PQ_NhomQuyenForCreationDto nhomQuyen)
        {
            var query = "exec  inserted_PQ_NhomQuyen 0, @Ten " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Ten", nhomQuyen.Ten, DbType.String);
            

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new PQ_NhomQuyen
                {
                    Id_NQ = id,
                    Ten = nhomQuyen.Ten
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
        public async Task UpdatePQ_NhomQuyen(PQ_NhomQuyenForUpdateDto nhomQuyen)
        {
            var query = "exec  inserted_PQ_NhomQuyen @Id_NQ,@Ten";

            var parameters = new DynamicParameters();
            parameters.Add("Id_NQ", nhomQuyen.Id_NQ, DbType.Int32);
            parameters.Add("Ten", nhomQuyen.Ten, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePQ_NhomQuyen(int Id_NQ)
        {
            var query = "exec deleted 5, @Id_NQ  exec deleted 6, @Id_NQ  exec deleted 7, @Id_NQ";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_NQ });
            }
        }
        /*public async Task<PQ_NhomQuyen> GetPQ_NhomQuyenByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_PQ_NhomQuyen_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<PQ_NhomQuyen>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<PQ_NhomQuyen>> GetPQ_NhomQuyenPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_PQ_NhomQuyen_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, PQ_NhomQuyen>();

                var companies = await connection.QueryAsync<PQ_NhomQuyen, CT_NhanHieu, PQ_NhomQuyen>(
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
