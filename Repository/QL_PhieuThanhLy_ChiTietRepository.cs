using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QL_PhieuThanhLy_ChiTietRepository : IQL_PhieuThanhLy_ChiTietRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QL_PhieuThanhLy_ChiTietRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QL_PhieuThanhLy_ChiTiet_HT>> GetQL_PhieuThanhLy_ChiTiet()
        {
            var query = "exec Select_QL_PhieuThanhLy_ChiTiet_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QL_PhieuThanhLy_ChiTiet_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QL_PhieuThanhLy_ChiTiet> GetQL_PhieuThanhLy_ChiTiet(int ID)
        {
            var query = "exec  selectedtk 11, @ID";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QL_PhieuThanhLy_ChiTiet>(query, new { ID });

                return company;
            }
        }
        /*public async Task CreateQL_PhieuThanhLy_ChiTiet(QL_PhieuThanhLy_ChiTietForCreationDto taiKhoan)
        {
            var query = "Insert into QL_PhieuThanhLy_ChiTiet (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QL_PhieuThanhLy_ChiTiet> CreateQL_PhieuThanhLy_ChiTiet(QL_PhieuThanhLy_ChiTietForCreationDto phieuThanhlyct)
        {
            var query = "exec  inserted_QL_PhieuThanhLy_ChiTiet 0,@TenTS " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            
            parameters.Add("TenTS", phieuThanhlyct.TenTS, DbType.String);
            


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QL_PhieuThanhLy_ChiTiet
                {
                    ID = id,
                    
                    
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
        public async Task UpdateQL_PhieuThanhLy_ChiTiet(QL_PhieuThanhLy_ChiTietForUpdateDto phieuThanhlyct)
        {
            var query = "exec inserted_QL_PhieuThanhLy_ChiTiet @Id_PTL,@TenTS";

            var parameters = new DynamicParameters();
            
            parameters.Add("Id_PTL", phieuThanhlyct.Id_PTL, DbType.Int32);
            
            parameters.Add("TenTS", phieuThanhlyct.TenTS, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQL_PhieuThanhLy_ChiTiet(int Id_PTL)
        {
            var query = "exec deleted 11, @Id_PTL";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PTL });
            }
        }
        /*public async Task<QL_PhieuThanhLy_ChiTiet> GetQL_PhieuThanhLy_ChiTietByQL_PhieuThanhLy_ChiTiet_TKid(int id)
        {
            var procedureName = "select_QL_PhieuThanhLy_ChiTiet_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QL_PhieuThanhLy_ChiTiet>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QL_PhieuThanhLy_ChiTiet>> GetQL_PhieuThanhLy_ChiTietQL_PhieuThanhLy_ChiTiet_TKMultipleMapping()
        {
            var query = "select_QL_PhieuThanhLy_ChiTiet_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QL_PhieuThanhLy_ChiTiet>();

                var companies = await connection.QueryAsync<QL_PhieuThanhLy_ChiTiet, CT_NhanHieu, QL_PhieuThanhLy_ChiTiet>(
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
