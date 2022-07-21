using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QL_PhieuThuHoi_ChiTietRepository : IQL_PhieuThuHoi_ChiTietRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QL_PhieuThuHoi_ChiTietRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QL_PhieuThuHoi_ChiTiet_HT>> GetQL_PhieuThuHoi_ChiTiet()
        {
            var query = "exec Select_QL_PhieuThuHoi_ChiTiet_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QL_PhieuThuHoi_ChiTiet_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QL_PhieuThuHoi_ChiTiet> GetQL_PhieuThuHoi_ChiTiet(int ID)
        {
            var query = "exec  selectedtk 13, @ID";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QL_PhieuThuHoi_ChiTiet>(query, new { ID });

                return company;
            }
        }
        /*public async Task CreateQL_PhieuThuHoi_ChiTiet(QL_PhieuThuHoi_ChiTietForCreationDto taiKhoan)
        {
            var query = "Insert into QL_PhieuThuHoi_ChiTiet (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QL_PhieuThuHoi_ChiTiet> CreateQL_PhieuThuHoi_ChiTiet(QL_PhieuThuHoi_ChiTietForCreationDto phieuThuhoict)
        {
            var query = "exec  inserted_QL_PhieuThuHoi_ChiTiet 0,@TenTS " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            
            parameters.Add("TenTS", phieuThuhoict.TenTS, DbType.String);
            


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QL_PhieuThuHoi_ChiTiet
                {
                    ID = id,
                    
                    TenTS = phieuThuhoict.TenTS
                    
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
        public async Task UpdateQL_PhieuThuHoi_ChiTiet(QL_PhieuThuHoi_ChiTietForUpdateDto phieuThuhoict)
        {
            var query = "exec  inserted_QL_PhieuThuHoi_ChiTiet @Id_PTH,@TenTS";

            var parameters = new DynamicParameters();
            
            parameters.Add("Id_PTH", phieuThuhoict.Id_PTH, DbType.Int32);
            
            parameters.Add("TenTS", phieuThuhoict.TenTS, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQL_PhieuThuHoi_ChiTiet(int Id_PTH)
        {
            var query = "exec deleted 13, @Id_PTH";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PTH });
            }
        }
        /*public async Task<QL_PhieuThuHoi_ChiTiet> GetQL_PhieuThuHoi_ChiTietByQL_PhieuThuHoi_ChiTiet_TKid(int id)
        {
            var procedureName = "select_QL_PhieuThuHoi_ChiTiet_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QL_PhieuThuHoi_ChiTiet>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QL_PhieuThuHoi_ChiTiet>> GetQL_PhieuThuHoi_ChiTietQL_PhieuThuHoi_ChiTiet_TKMultipleMapping()
        {
            var query = "select_QL_PhieuThuHoi_ChiTiet_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QL_PhieuThuHoi_ChiTiet>();

                var companies = await connection.QueryAsync<QL_PhieuThuHoi_ChiTiet, CT_NhanHieu, QL_PhieuThuHoi_ChiTiet>(
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
