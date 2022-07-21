using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class CT_ChiTietLoaiTSRepository : ICT_ChiTietLoaiTSRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public CT_ChiTietLoaiTSRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CT_ChiTietLoaiTS>> GetCT_ChiTietLoaiTS()
        {
            var query = "exec  selected 1";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<CT_ChiTietLoaiTS>(query);
                return compan.ToList();
            }
        }
        public async Task<CT_ChiTietLoaiTS> GetCT_ChiTietLoaiTS(int Id_Loai)
        {
            var query = "exec selectedtk 1, @Id_Loai";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<CT_ChiTietLoaiTS>(query, new { Id_Loai });

                return company;
            }
        }
        /*public async Task CreateCT_ChiTietLoaiTS(CT_ChiTietLoaiTSForCreationDto taiKhoan)
        {
            var query = "Insert into CT_ChiTietLoaiTS (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<CT_ChiTietLoaiTS> CreateCT_ChiTietLoaiTS(CT_ChiTietLoaiTSForCreationDto loai)
        {
            var query = "exec  inserted_CT_ChiTietLoaiTS 0,@NhomLoai,@Ten,@PhanLoai,@MoTa " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("NhomLoai", loai.NhomLoai, DbType.String);
            parameters.Add("Ten", loai.Ten, DbType.String);
            parameters.Add("PhanLoai", loai.PhanLoai, DbType.String);
            parameters.Add("MoTa", loai.MoTa, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new CT_ChiTietLoaiTS
                {
                    Id_Loai = id,
                    Ten = loai.Ten,
                    PhanLoai = loai.PhanLoai,
                    MoTa = loai.MoTa
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
        public async Task UpdateCT_ChiTietLoaiTS(CT_ChiTietLoaiTSForUpdateDto loai)
        {
            var query = "exec  inserted_CT_ChiTietLoaiTS @Id_Loai,@NhomLoai,@Ten,@PhanLoai,@MoTa";

            var parameters = new DynamicParameters();
            parameters.Add("Id_Loai", loai.Id_Loai, DbType.Int32);
            parameters.Add("NhomLoai", loai.NhomLoai, DbType.Int32);
            parameters.Add("Ten", loai.Ten, DbType.String);
            parameters.Add("PhanLoai", loai.PhanLoai, DbType.String);
            parameters.Add("MoTa", loai.MoTa, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCT_ChiTietLoaiTS(int Id_Loai)
        {
            var query = "exec deleted 1, @Id_Loai";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id_Loai });
            }
        }
        /*public async Task<CT_ChiTietLoaiTS> GetCT_ChiTietLoaiTSByPQ_NhomQuyen_TKid(int id)
        {
            var procedureName = "select_CT_ChiTietLoaiTS_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<CT_ChiTietLoaiTS>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }*/
        /*public async Task<List<CT_ChiTietLoaiTS>> GetCT_ChiTietLoaiTSPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_CT_ChiTietLoaiTS_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, CT_ChiTietLoaiTS>();

                var companies = await connection.QueryAsync<CT_ChiTietLoaiTS, CT_NhanHieu, CT_ChiTietLoaiTS>(
                    query, (phongBan, nhanHieu) =>
                    {
                        if (!companyDict.TryGetValue(phongBan.Id_PB, out var currentCompany))
                        {
                            currentCompany = phongBan;
                            companyDict.Add(currentCompany.Id_PB, currentCompany);
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
