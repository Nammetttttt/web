using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QL_PhieuXuat_ChiTietRepository : IQL_PhieuXuat_ChiTietRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QL_PhieuXuat_ChiTietRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QL_PhieuXuat_ChiTiet_HT>> GetQL_PhieuXuat_ChiTiet()
        {
            var query = "exec Select_QL_PhieuXuat_ChiTiet_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QL_PhieuXuat_ChiTiet_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QL_PhieuXuat_ChiTiet> GetQL_PhieuXuat_ChiTiet(int ID)
        {
            var query = "exec  selectedtk 15, @ID";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QL_PhieuXuat_ChiTiet>(query, new { ID });

                return company;
            }
        }
        /*public async Task CreateQL_PhieuXuat_ChiTiet(QL_PhieuXuat_ChiTietForCreationDto taiKhoan)
        {
            var query = "Insert into QL_PhieuXuat_ChiTiet (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QL_PhieuXuat_ChiTiet> CreateQL_PhieuXuat_ChiTiet(QL_PhieuXuat_ChiTietForCreationDto phieuXuatct)
        {
            var query = "exec inserted_QL_PhieuXuat_ChiTiet 0, @TenTS " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
          
            parameters.Add("TenTS", phieuXuatct.TenTS, DbType.String);
            


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QL_PhieuXuat_ChiTiet
                {
                    ID = id,
                   
                    TenTS = phieuXuatct.TenTS
                    
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
        public async Task UpdateQL_PhieuXuat_ChiTiet(QL_PhieuXuat_ChiTietForUpdateDto phieuThuhoict)
        {
            var query = "exec inserted_QL_PhieuXuat_ChiTiet @Id_PX,@TenTS";

            var parameters = new DynamicParameters();
        
            parameters.Add("Id_PX", phieuThuhoict.Id_PX, DbType.Int32);
           
            parameters.Add("TenTS", phieuThuhoict.TenTS, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQL_PhieuXuat_ChiTiet(int Id_PX)
        {
            var query = "exec deleted 15, @Id_PX";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PX });
            }
        }
        /*public async Task<QL_PhieuXuat_ChiTiet> GetQL_PhieuXuat_ChiTietByQL_PhieuXuat_ChiTiet_TKid(int id)
        {
            var procedureName = "select_QL_PhieuXuat_ChiTiet_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QL_PhieuXuat_ChiTiet>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QL_PhieuXuat_ChiTiet>> GetQL_PhieuXuat_ChiTietQL_PhieuXuat_ChiTiet_TKMultipleMapping()
        {
            var query = "select_QL_PhieuXuat_ChiTiet_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QL_PhieuXuat_ChiTiet>();

                var companies = await connection.QueryAsync<QL_PhieuXuat_ChiTiet, CT_NhanHieu, QL_PhieuXuat_ChiTiet>(
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
