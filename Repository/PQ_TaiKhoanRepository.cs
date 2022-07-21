using ASP.NET8.Context;

using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class PQ_TaiKhoanRepon : IPQ_TaiKhoanRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext dapperContext; 
        
        public PQ_TaiKhoanRepon(DapperContext context)
        {
            dapperContext = context;
        }
        public async Task<IEnumerable<PQ_TaiKhoan_HT>> GetPQ_TaiKhoan()
        {
            var query = "exec select_PQ_TaiKhoan_TK_HT";

            using (var connection = dapperContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<PQ_TaiKhoan_HT>(query);
                return companies.ToList();
            }
        }
        public async Task<PQ_TaiKhoan> GetPQ_TaiKhoan(int Id_TK)
        {
            var query = "exec  selectedtk 8, @Id_TK";

            using (var connection = dapperContext.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_TaiKhoan>(query, new { Id_TK });

                return company;
            }
        }
        /*public async Task CreatePQ_TaiKhoan(PQ_TaiKhoanForCreationDto taiKhoan)
        {
            var query = "Insert into PQ_TaiKhoan (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<PQ_TaiKhoan> CreatePQ_TaiKhoan(PQ_TaiKhoanForCreationDto taiKhoan)
        {
            var query = "exec  inserted_PQ_TaiKhoan 0, @TenTK, @MatKhau, @Ten ";
                /*" CREATE LOGIN @TenTK  WITH PASSWORD = @MatKhau;" +
                "CREATE USER @TenTK FOR LOGIN @TenTK;"+
                "GRANT ALL On[QLTS].[dbo].[CT_ChiTietLoaiTS] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[CT_Kho] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[CT_NhanHieu] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[PQ_ChucNang] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[PQ_NhomQuyen] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[PQ_NhomQuyen_CN] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[PQ_NhomQuyen_TK] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[PQ_TaiKhoan] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QL_PhieuNhap] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QL_PhieuThanhLy] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QL_PhieuThanhLy_ChiTiet] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QL_PhieuThuHoi] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QL_PhieuThuHoi_ChiTiet] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QL_PhieuXuat] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QL_PhieuXuat_ChiTiet] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QT_NhanVien] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QT_PhongBan] TO @TenTK;" +
                "GRANT ALL On[QLTS].[dbo].[QT_TaiSan] TO @TenTK;" +
                "GRANT EXECUTE ON SCHEMA::dbo  TO @TenTK; ";*/


            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("Ten", taiKhoan.Ten, DbType.String);

            using (var connection = dapperContext.CreateConnection())
                {
                    var id = await connection.QuerySingleAsync<int>(query, parameters);

                    var createdTaiKhoan = new PQ_TaiKhoan
                    {
                        Id_TK = id,
                        TenTK = taiKhoan.TenTK,
                        MatKhau = taiKhoan.MatKhau
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
        public async Task UpdatePQ_TaiKhoan(PQ_TaiKhoanForUpdateDto taiKhoan)
        {
            var query = "exec  inserted_PQ_TaiKhoan @Id_TK,@TenTK, @MatKhau, @Ten";

            var parameters = new DynamicParameters();
            parameters.Add("Id_TK", taiKhoan.Id_TK, DbType.Int32);
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("Ten", taiKhoan.Ten, DbType.String);
            using (var connection = dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePQ_TaiKhoan(int Id_TK)
        {
            var query = "exec deleted 8, @Id_TK  exec deleted2 7,@Id_TK";

            using (var connection = dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_TK });
            }
        }
       /* public async Task<PQ_TaiKhoan> GetPQ_TaiKhoanByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_PQ_TaiKhoan_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = dapperContext.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<PQ_TaiKhoan>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }*/
        /*public async Task<List<PQ_TaiKhoan>> GetPQ_TaiKhoanPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_PQ_TaiKhoan_TK1";

            using (var connection = dapperContext.CreateConnection())
            {
                var companyDict = new Dictionary<int, PQ_TaiKhoan>();

                var companies = await connection.QueryAsync<PQ_TaiKhoan, PQ_NhomQuyen_TK, PQ_TaiKhoan>(
                    query, (taiKhoan, nhomQuyen) =>
                    {
                        if (!companyDict.TryGetValue(taiKhoan.Id_TK, out var currentCompany))
                        {
                            currentCompany = taiKhoan;
                            companyDict.Add(currentCompany.Id_TK, currentCompany);
                        }

                        currentCompany.PQ_NhomQuyen_TKs.Add(nhomQuyen);
                        return currentCompany;
                    }
                    
                );

                return companies.Distinct().ToList();
            }
        }*/

    }
}
