using ASP.NET8.Context;
using ASP.NET8.Contracts;
using ASP.NET8.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPQ_TaiKhoanRepository, PQ_TaiKhoanRepon>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQT_TaiSanRepository, QT_TaiSanRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQT_PhongBanRepository, QT_PhongBanRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPQ_NhomQuyenRepository, PQ_NhomQuyenRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPQ_ChucNangRepository, PQ_ChucNangRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPQ_NhomQuyen_CNRepository, PQ_NhomQuyen_CNRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPQ_NhomQuyen_TKRepository, PQ_NhomQuyen_TKRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICT_KhoRepository, CT_KhoRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICT_ChiTietLoaiTSRepository, CT_ChiTietLoaiTSRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICT_NhanHieuRepository, CT_NhanHieuRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQL_PhieuNhapRepository, QL_PhieuNhapRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQL_PhieuThanhLyRepository, QL_PhieuThanhLyRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQL_PhieuThanhLy_ChiTietRepository, QL_PhieuThanhLy_ChiTietRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQL_PhieuThuHoiRepository, QL_PhieuThuHoiRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQL_PhieuThuHoi_ChiTietRepository, QL_PhieuThuHoi_ChiTietRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQL_PhieuXuatRepository, QL_PhieuXuatRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQL_PhieuXuat_ChiTietRepository, QL_PhieuXuat_ChiTietRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IQT_NhanVienRepository, QT_NhanVienRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPQ_TaiKhoan_DNRepository, PQ_TaiKhoan_DNRepon>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
