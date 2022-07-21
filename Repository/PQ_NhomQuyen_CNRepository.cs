using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class PQ_NhomQuyen_CNRepository : IPQ_NhomQuyen_CNRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        public PQ_NhomQuyen_CNRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PQ_NhomQuyen_CN_HT>> GetPQ_NhomQuyen_CN()
        {
            var query = "exec Select_PQ_NhomQuyen_CN_HT";

            using (var connection = _context.CreateConnection())
            {
                var compan = await connection.QueryAsync<PQ_NhomQuyen_CN_HT>(query);
                return compan.ToList();
            }
        }
        public async Task<PQ_NhomQuyen_CN> GetPQ_NhomQuyen_CN(int Id_NQ)
        {
            var query = "exec  selectedtk 6, @Id_NQ";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_NhomQuyen_CN>(query, new { Id_NQ });

                return company;
            }
        }
        public async Task<PQ_NhomQuyen_CN> GetPQ_NhomQuyen_CN_(int ID)
        {
            var query = "exec  selectedtk1 6, @ID";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_NhomQuyen_CN>(query, new { ID });

                return company;
            }
        }
        /*public async Task CreatePQ_NhomQuyen_CN(PQ_NhomQuyen_CNForCreationDto taiKhoan)
        {
            var query = "Insert into PQ_NhomQuyen_CN (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        public async Task<PQ_NhomQuyen_CN> CreatePQ_NhomQuyen_CN(PQ_NhomQuyen_CNForCreationDto NQ_chucNang)
        {
            var query = "exec  inserted_PQ_NhomQuyen_CN 0, @Ten,@MoTa " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Ten", NQ_chucNang.Ten, DbType.String);
            parameters.Add("MoTa", NQ_chucNang.MoTa, DbType.String);
            


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTaiKhoan = new PQ_NhomQuyen_CN
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
        public async Task UpdatePQ_NhomQuyen_CN(PQ_NhomQuyen_CNForUpdateDto NQ_chucNang)
        {
            var query = "exec  inserted_PQ_NhomQuyen_CN @ID,@Id_CN,@Id_NQ,@Xem,@Them,@Sua,@Xoa";

            var parameters = new DynamicParameters();
            parameters.Add("ID", NQ_chucNang.ID, DbType.Int32);
            parameters.Add("Id_CN", NQ_chucNang.Id_CN, DbType.Int32);
            parameters.Add("Id_NQ", NQ_chucNang.Id_NQ, DbType.Int32);
            parameters.Add("Xem", NQ_chucNang.Xem, DbType.Int32);
            parameters.Add("Them", NQ_chucNang.Them, DbType.Int32);
            parameters.Add("Sua", NQ_chucNang.Sua, DbType.Int32);
            parameters.Add("Xoa", NQ_chucNang.Xoa, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePQ_NhomQuyen_CN(int ID)
        {
            var query = "exec deleted1 6, @ID";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { ID });
            }
        }
        /*public async Task<PQ_NhomQuyen_CN> GetPQ_NhomQuyen_CNByPQ_NhomQuyen_CN_TKid(int id)
        {
            var procedureName = "select_PQ_NhomQuyen_CN_TK";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<PQ_NhomQuyen_CN>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }
        public async Task<List<PQ_NhomQuyen_CN>> GetPQ_NhomQuyen_CNPQ_NhomQuyen_CN_TKMultipleMapping()
        {
            var query = "select_PQ_NhomQuyen_CN_TK1";

            using (var connection = _context.CreateConnection())
            {
                var companyDict = new Dictionary<int, PQ_NhomQuyen_CN>();

                var companies = await connection.QueryAsync<PQ_NhomQuyen_CN, CT_NhanHieu, PQ_NhomQuyen_CN>(
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
