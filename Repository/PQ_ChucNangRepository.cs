using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class PQ_ChucNangRepository : IPQ_ChucNangRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public PQ_ChucNangRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PQ_ChucNang>> GetPQ_ChucNang()
        {
            var query = "exec  selected 4";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<PQ_ChucNang>(query);
                return compan.ToList();
            }
        }
        public async Task<PQ_ChucNang> GetPQ_ChucNang(int Id_CN)
        {
            var query = "exec  selectedtk 4, @Id_CN";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_ChucNang>(query, new { Id_CN });

                return company;
            }
        }
        /*public async Task CreatePQ_ChucNang(PQ_ChucNangForCreationDto taiKhoan)
        {
            var query = "Insert into PQ_ChucNang (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<PQ_ChucNang> CreatePQ_ChucNang(PQ_ChucNangForCreationDto chucNang)
        {
            var query = "exec  inserted_PQ_ChucNang 0, @MoTa " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Mota", chucNang.MoTa, DbType.String);
            

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new PQ_ChucNang
                {
                    Id_CN = id,
                    MoTa = chucNang.MoTa
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
        public async Task UpdatePQ_ChucNang(PQ_ChucNangForUpdateDto chucNang)
        {
            var query = "exec  inserted_PQ_ChucNang  @Id_CN,@MoTa";

            var parameters = new DynamicParameters();
            parameters.Add("Id_CN", chucNang.Id_CN, DbType.Int32);
            parameters.Add("MoTa", chucNang.MoTa, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePQ_ChucNang(int Id_CN)
        {
            var query = "deleted 4, @Id_CN  exec deleted2 6,@Id_CN";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_CN });
            }
        }
        /*public async Task<PQ_ChucNang> GetPQ_ChucNangByPQ_ChucNang_TKid(int id)
        {
            var procedureName = "select_PQ_ChucNang_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<PQ_ChucNang>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<PQ_ChucNang>> GetPQ_ChucNangPQ_ChucNang_TKMultipleMapping()
        {
            var query = "select_PQ_ChucNang_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, PQ_ChucNang>();

                var companies = await connection.QueryAsync<PQ_ChucNang, CT_NhanHieu, PQ_ChucNang>(
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
