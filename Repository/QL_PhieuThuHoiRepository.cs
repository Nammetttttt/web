using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QL_PhieuThuHoiRepository : IQL_PhieuThuHoiRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QL_PhieuThuHoiRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QL_PhieuThuHoi_HT>> GetQL_PhieuThuHoi()
        {
            var query = "exec Select_QL_PhieuThuHoi_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QL_PhieuThuHoi_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QL_PhieuThuHoi> GetQL_PhieuThuHoi(int Id_PTH)
        {
            var query = "exec  selectedtk 12, @Id_PTH";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QL_PhieuThuHoi>(query, new { Id_PTH });

                return company;
            }
        }
        /*public async Task CreateQL_PhieuThuHoi(QL_PhieuThuHoiForCreationDto taiKhoan)
        {
            var query = "Insert into QL_PhieuThuHoi (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QL_PhieuThuHoi> CreateQL_PhieuThuHoi(QL_PhieuThuHoiForCreationDto phieuThuhoi)
        {
            var query = "exec  inserted_QL_PhieuThuHoi 0, @SoPhieuTH,@NgayThuHoi,@Id_NV,@Id_Kho,@DienGiai " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("SoPhieuTH", phieuThuhoi.SoPhieuTH, DbType.String);
            parameters.Add("NgayThuHoi", phieuThuhoi.NgayThuHoi, DbType.DateTime);
            parameters.Add("Id_NV", phieuThuhoi.Id_NV, DbType.String);
            parameters.Add("Id_Kho", phieuThuhoi.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuThuhoi.DienGiai, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QL_PhieuThuHoi
                {
                    Id_PTH = id,
                    SoPhieuTH = phieuThuhoi.SoPhieuTH,
                    NgayThuHoi = phieuThuhoi.NgayThuHoi,
                    TenNV = phieuThuhoi.Id_NV,
                    MoTa = phieuThuhoi.Id_Kho,
                    DienGiai = phieuThuhoi.DienGiai
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
        public async Task UpdateQL_PhieuThuHoi(QL_PhieuThuHoiForUpdateDto phieuThuhoi)
        {
            var query = "exec  inserted_QL_PhieuThuHoi @Id_PTH,@SoPhieuTH,@NgayThuHoi,@Id_NV,@Id_Kho,@DienGiai";

            var parameters = new DynamicParameters();
            parameters.Add("Id_PTH", phieuThuhoi.Id_PTH, DbType.Int32);
            parameters.Add("SoPhieuTH", phieuThuhoi.SoPhieuTH, DbType.String);
            parameters.Add("NgayThuHoi", phieuThuhoi.NgayThuHoi, DbType.DateTime);
            parameters.Add("Id_NV", phieuThuhoi.Id_NV, DbType.String);
            parameters.Add("Id_Kho", phieuThuhoi.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuThuhoi.DienGiai, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQL_PhieuThuHoi(int Id_PTH)
        {
            var query = "exec deleted 12, @Id_PTH  exec deleted 13, @Id_PTH";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PTH });
            }
        }
        /*public async Task<QL_PhieuThuHoi> GetQL_PhieuThuHoiByQL_PhieuThuHoi_TKid(int id)
        {
            var procedureName = "select_QL_PhieuThuHoi_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QL_PhieuThuHoi>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QL_PhieuThuHoi>> GetQL_PhieuThuHoiQL_PhieuThuHoi_TKMultipleMapping()
        {
            var query = "select_QL_PhieuThuHoi_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QL_PhieuThuHoi>();

                var companies = await connection.QueryAsync<QL_PhieuThuHoi, CT_NhanHieu, QL_PhieuThuHoi>(
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
