using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Dto;
using ASP.NET8.Entities;
using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace ASP.NET8.Repository
{
    public class PQ_TaiKhoan_DNRepon : IPQ_TaiKhoan_DNRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext dapperContext;
        public PQ_TaiKhoan_DNRepon(DapperContext context)
        {
            dapperContext = context;
        }
        //public async Task<IEnumerable<PQ_TaiKhoan_DN>> GetPQ_TaiKhoan_DN()
        //{
        //    var query = "exec  selected 8";

        //    using (var connection = dapperContext.CreateConnection())
        //    {
        //        var companies = await connection.QueryAsync<PQ_TaiKhoan_DN>(query);
        //        return companies.ToList();
        //    }
        //}
        public async Task<PQ_TaiKhoan_DN> GetPQ_TaiKhoan_DN(PQ_TaiKhoan_DNForCreationDto nguoidung)
        {
            var query = "exec selected_PQ_TaiKhoan @TenTK, @MatKhau";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", nguoidung.TenTK, DbType.String);
            parameters.Add("MatKhau", nguoidung.MatKhau, DbType.String);

            using (var connection = dapperContext.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_TaiKhoan_DN>(query, new { nguoidung.TenTK, nguoidung.MatKhau });
                
                return company;
            }
            
        }
        public async Task<PQ_TaiKhoan_DN> GetPQ_TaiKhoan_DN1(PQ_TaiKhoan_DNForCreationDto nguoidung)
        {
            
            var query = "exec selected_PQ_TaiKhoan1 @TenTK, @MatKhau";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", nguoidung.TenTK, DbType.String);
            parameters.Add("MatKhau", nguoidung.MatKhau, DbType.String);
            
            using (var connection = dapperContext.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<PQ_TaiKhoan_DN>(query, new { nguoidung.TenTK, nguoidung.MatKhau });
                
                return company;
            }
            

        }
        /*public async Task CreatePQ_TaiKhoan_DN(PQ_TaiKhoan_DNForCreationDto taiKhoan)
        {
            var query = "Insert into PQ_TaiKhoan_DN (TenTK,MatKhau,NhomQuyen)  values (@TenTK, @MatKhau, @NhomQuyen) ";

            var parameters = new DynamicParameters();
            parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
            parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);
            parameters.Add("NhomQuyen", taiKhoan.NhomQuyen, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }*/
        //public async Task<PQ_TaiKhoan_DN> CreatePQ_TaiKhoan_DN(PQ_TaiKhoan_DNForCreationDto taiKhoan)
        //{
        //    var query = "exec  inserted_PQ_TaiKhoan_DN 0, @TenTK, @MatKhau ";


        //    var parameters = new DynamicParameters();
        //    parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
        //    parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);

        //    using (var connection = dapperContext.CreateConnection())
        //    {
        //        var id = await connection.QuerySingleAsync<int>(query, parameters);

        //        var createdTaiKhoan = new PQ_TaiKhoan_DN
        //        {

        //            TenTK = taiKhoan.TenTK,
        //            MatKhau = taiKhoan.MatKhau
        //        };

        //        return createdTaiKhoan;
        //    }
        //    /*DataTable table = new DataTable();
        //    String sqlDataSource = _configuration.GetConnectionString("QLTS");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //        return new JsonResult(table);
        //    }*/
        //}
        //public async Task UpdatePQ_TaiKhoan_DN(int Id_TK, PQ_TaiKhoan_DNForUpdateDto taiKhoan)
        //{
        //    var query = "exec  inserted_PQ_TaiKhoan_DN @Id_TK,@TenTK, @MatKhau ";

        //    var parameters = new DynamicParameters();
        //    parameters.Add("Id_TK", Id_TK, DbType.Int32);
        //    parameters.Add("TenTK", taiKhoan.TenTK, DbType.String);
        //    parameters.Add("MatKhau", taiKhoan.MatKhau, DbType.String);

        //    using (var connection = dapperContext.CreateConnection())
        //    {
        //        await connection.ExecuteAsync(query, parameters);
        //    }
        //}

        //public async Task DeletePQ_TaiKhoan_DN(int Id_TK)
        //{
        //    var query = "exec deleted 8, @Id_TK";

        //    using (var connection = dapperContext.CreateConnection())
        //    {
        //        await connection.ExecuteAsync(query, new { Id_TK });
        //    }
        //}
        /* public async Task<PQ_TaiKhoan_DN> GetPQ_TaiKhoan_DNByPQ_NhomQuyen_TKid(int id)
         {
             var procedureName = "select_PQ_TaiKhoan_DN_TK";
             var parameters = new DynamicParameters();
             parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

             using (var connection = dapperContext.CreateConnection())
             {
                 var company = await connection.QueryFirstOrDefaultAsync<PQ_TaiKhoan_DN>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                 return company;
             }
         }*/
        /*public async Task<List<PQ_TaiKhoan_DN>> GetPQ_TaiKhoan_DNPQ_NhomQuyen_TKMultipleMapping()
        {
            var query = "select_PQ_TaiKhoan_DN_TK1";

            using (var connection = dapperContext.CreateConnection())
            {
                var companyDict = new Dictionary<int, PQ_TaiKhoan_DN>();

                var companies = await connection.QueryAsync<PQ_TaiKhoan_DN, PQ_NhomQuyen_TK, PQ_TaiKhoan_DN>(
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
