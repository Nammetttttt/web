using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QL_PhieuThanhLyRepository : IQL_PhieuThanhLyRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QL_PhieuThanhLyRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QL_PhieuThanhLy_HT>> GetQL_PhieuThanhLy()
        {
            var query = "exec Select_QL_PhieuThanhLy_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QL_PhieuThanhLy_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QL_PhieuThanhLy> GetQL_PhieuThanhLy(int Id_PTL)
        {
            var query = "exec  selectedtk 10, @Id_PTL";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QL_PhieuThanhLy>(query, new { Id_PTL });

                return company;
            }
        }
        /*public async Task CreateQL_PhieuThanhLy(QL_PhieuThanhLyForCreationDto taiKhoan)
        {
            var query = "Insert into QL_PhieuThanhLy (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QL_PhieuThanhLy> CreateQL_PhieuThanhLy(QL_PhieuThanhLyForCreationDto phieuThanhly)
        {
            var query = "exec  inserted_QL_PhieuThanhLy 0, @SoPhieuThanhLy,@NgayThanhLy,@Id_NV,@Id_Kho,@DienGiai " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("SoPhieuThanhLy", phieuThanhly.SoPhieuThanhLy, DbType.String);
            parameters.Add("NgayThanhLy", phieuThanhly.NgayThanhLy, DbType.DateTime);
            parameters.Add("Id_NV", phieuThanhly.Id_NV, DbType.String);
            parameters.Add("Id_Kho", phieuThanhly.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuThanhly.DienGiai, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QL_PhieuThanhLy
                {
                    Id_PTL = id,
                    SoPhieuThanhLy = phieuThanhly.SoPhieuThanhLy,
                    NgayThanhLy = phieuThanhly.NgayThanhLy,
                    TenNV = phieuThanhly.Id_NV,
                    
                    MoTa = phieuThanhly.Id_Kho,
                    DienGiai = phieuThanhly.DienGiai
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
        public async Task UpdateQL_PhieuThanhLy(QL_PhieuThanhLyForUpdateDto phieuThanhly)
        {
            var query = "exec  inserted_QL_PhieuThanhLy @Id_PTL,@SoPhieuThanhLy,@NgayThanhLy,@Id_NV,@Id_Kho,@DienGiai";

            var parameters = new DynamicParameters();
            parameters.Add("Id_PTL", phieuThanhly.Id_PTL, DbType.Int32);
            parameters.Add("SoPhieuThanhLy", phieuThanhly.SoPhieuThanhLy, DbType.String);
            parameters.Add("NgayThanhLy", phieuThanhly.NgayThanhLy, DbType.DateTime);
            parameters.Add("Id_NV", phieuThanhly.Id_NV, DbType.String);
            parameters.Add("Id_Kho", phieuThanhly.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuThanhly.DienGiai, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQL_PhieuThanhLy(int Id_PTL)
        {
            var query = "exec deleted 10, @Id_PTL  exec deleted 11, @Id_PTL";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PTL });
            }
        }
        /*public async Task<QL_PhieuThanhLy> GetQL_PhieuThanhLyByQL_PhieuThanhLy_TKid(int id)
        {
            var procedureName = "select_QL_PhieuThanhLy_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QL_PhieuThanhLy>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QL_PhieuThanhLy>> GetQL_PhieuThanhLyQL_PhieuThanhLy_TKMultipleMapping()
        {
            var query = "select_QL_PhieuThanhLy_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QL_PhieuThanhLy>();

                var companies = await connection.QueryAsync<QL_PhieuThanhLy, CT_NhanHieu, QL_PhieuThanhLy>(
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
