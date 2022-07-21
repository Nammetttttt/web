using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QL_PhieuXuatRepository : IQL_PhieuXuatRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QL_PhieuXuatRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QL_PhieuXuat_HT>> GetQL_PhieuXuat()
        {
            var query = "exec Select_QL_PhieuXuat_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QL_PhieuXuat_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QL_PhieuXuat> GetQL_PhieuXuat(int Id_PX)
        {
            var query = "exec selectedtk 14, @Id_PX";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QL_PhieuXuat>(query, new { Id_PX });

                return company;
            }
        }
        /*public async Task CreateQL_PhieuXuat(QL_PhieuXuatForCreationDto taiKhoan)
        {
            var query = "Insert into QL_PhieuXuat (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QL_PhieuXuat> CreateQL_PhieuXuat(QL_PhieuXuatForCreationDto phieuXuat)
        {
            var query = "exec inserted_QL_PhieuXuat 0, @SoPhieuXuat,@NgayXuat,@ViTriSuDung,@Id_PB,@Id_NV,@Id_Kho,@DienGiai " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("SoPhieuXuat", phieuXuat.SoPhieuXuat, DbType.String);
            parameters.Add("NgayXuat", phieuXuat.NgayXuat, DbType.DateTime);
            parameters.Add("ViTriSuDung", phieuXuat.ViTriSuDung, DbType.String);
            parameters.Add("Id_PB", phieuXuat.Id_PB, DbType.String);
            parameters.Add("Id_NV", phieuXuat.Id_NV, DbType.String);
            parameters.Add("Id_Kho", phieuXuat.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuXuat.DienGiai, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QL_PhieuXuat
                {
                    Id_PX = id,
                    SoPhieuXuat = phieuXuat.SoPhieuXuat,
                    NgayXuat = phieuXuat.NgayXuat,
                    ViTriSuDung = phieuXuat.ViTriSuDung,
                    TenPhongBan= phieuXuat.Id_PB,
                    TenNV = phieuXuat.Id_NV,
                    
                    MoTa = phieuXuat.Id_Kho,
                    DienGiai = phieuXuat.DienGiai
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
        public async Task UpdateQL_PhieuXuat(QL_PhieuXuatForUpdateDto phieuXuat)
        {
            var query = "exec inserted_QL_PhieuXuat @Id_PX,@SoPhieuXuat,@NgayXuat,@ViTriSuDung,@Id_PB,@Id_NV,@Id_Kho,@DienGiai";

            var parameters = new DynamicParameters();
            parameters.Add("Id_PX", phieuXuat.Id_PX, DbType.Int32);
            parameters.Add("SoPhieuXuat", phieuXuat.SoPhieuXuat, DbType.String);
            parameters.Add("NgayXuat", phieuXuat.NgayXuat, DbType.DateTime);
            parameters.Add("ViTriSuDung", phieuXuat.ViTriSuDung, DbType.String);
            parameters.Add("Id_PB", phieuXuat.Id_PB, DbType.String);
            parameters.Add("Id_NV", phieuXuat.Id_NV, DbType.String);
            parameters.Add("Id_Kho", phieuXuat.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuXuat.DienGiai, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQL_PhieuXuat(int Id_PX)
        {
            var query = "exec deleted 14, @Id_PX   exec deleted 15, @Id_PX";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PX });
            }
        }
        /*public async Task<QL_PhieuXuat> GetQL_PhieuXuatByQL_PhieuXuat_TKid(int id)
        {
            var procedureName = "select_QL_PhieuXuat_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QL_PhieuXuat>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QL_PhieuXuat>> GetQL_PhieuXuatQL_PhieuXuat_TKMultipleMapping()
        {
            var query = "select_QL_PhieuXuat_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QL_PhieuXuat>();

                var companies = await connection.QueryAsync<QL_PhieuXuat, CT_NhanHieu, QL_PhieuXuat>(
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
