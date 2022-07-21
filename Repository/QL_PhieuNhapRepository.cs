using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class QL_PhieuNhapRepository : IQL_PhieuNhapRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public QL_PhieuNhapRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QL_PhieuNhap_HT>> GetQL_PhieuNhap()
        {
            var query = "exec Select_QL_PhieuNhap_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<QL_PhieuNhap_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<QL_PhieuNhap> GetQL_PhieuNhap(int Id_PN)
        {
            var query = "exec  selectedtk 9, @Id_PN";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<QL_PhieuNhap>(query, new { Id_PN });

                return company;
            }
        }
        /*public async Task CreateQL_PhieuNhap(QL_PhieuNhapForCreationDto taiKhoan)
        {
            var query = "Insert into QL_PhieuNhap (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<QL_PhieuNhap> CreateQL_PhieuNhap(QL_PhieuNhapForCreationDto phieuNhap)
        {
            var query = "exec  inserted_QL_PhieuNhap 0, @SoPhieuNhap,@NgayNhap,@Id_NV,@Id_TK,@Id_Kho,@DienGiai " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("SoPhieuNhap", phieuNhap.SoPhieuNhap, DbType.String);
            parameters.Add("NgayNhap", phieuNhap.NgayNhap, DbType.DateTime);
            parameters.Add("Id_NV", phieuNhap.Id_NV, DbType.String);
            parameters.Add("Id_TK", phieuNhap.Id_TK, DbType.String);
            parameters.Add("Id_Kho", phieuNhap.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuNhap.DienGiai, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new QL_PhieuNhap
                {
                    Id_PN = id,
                    SoPhieuNhap = phieuNhap.SoPhieuNhap,
                    NgayNhap = phieuNhap.NgayNhap,
                    TenNV = phieuNhap.Id_NV,
                    TenTK = phieuNhap.Id_TK,
                    MoTa = phieuNhap.Id_Kho,
                    DienGiai = phieuNhap.DienGiai
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
        public async Task UpdateQL_PhieuNhap(QL_PhieuNhapForUpdateDto phieuNhap)
        {
            var query = "exec  inserted_QL_PhieuNhap @Id_PN,@SoPhieuNhap,@NgayNhap,@Id_NV,@Id_TK,@Id_Kho,@DienGiai";

            var parameters = new DynamicParameters();
            parameters.Add("Id_PN", phieuNhap.Id_PN, DbType.Int32);
            parameters.Add("SoPhieuNhap", phieuNhap.SoPhieuNhap, DbType.String);
            parameters.Add("NgayNhap", phieuNhap.NgayNhap, DbType.DateTime);
            parameters.Add("Id_NV", phieuNhap.Id_NV, DbType.String);
            parameters.Add("Id_TK", phieuNhap.Id_TK, DbType.String);
            parameters.Add("Id_Kho", phieuNhap.Id_Kho, DbType.String);
            parameters.Add("DienGiai", phieuNhap.DienGiai, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteQL_PhieuNhap(int Id_PN)
        {
            var query = "exec deleted 9, @Id_PN";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_PN });
            }
        }
        /*public async Task<QL_PhieuNhap> GetQL_PhieuNhapByQL_PhieuNhap_TKid(int id)
        {
            var procedureName = "select_QL_PhieuNhap_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<QL_PhieuNhap>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<QL_PhieuNhap>> GetQL_PhieuNhapQL_PhieuNhap_TKMultipleMapping()
        {
            var query = "select_QL_PhieuNhap_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, QL_PhieuNhap>();

                var companies = await connection.QueryAsync<QL_PhieuNhap, CT_NhanHieu, QL_PhieuNhap>(
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
