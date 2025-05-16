using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using MyWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using MyWebApi.ViewModel;
using MyWebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Nhập Token vào ",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

// Register services
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ILoginRepo, LoginRepo>();
builder.Services.AddScoped<IVaiTroRepo, VaiTroRepo>();
builder.Services.AddScoped<ITrangThaiThanhToanRepo, TrangThaiThanhToanRepo>();
builder.Services.AddScoped<IPhongRepo, PhongRepo>();
builder.Services.AddScoped<ILoaiPhongRepo, LoaiPhongRepo>();
builder.Services.AddScoped<ITrangThaiPhongRepo, TrangThaiPhongRepo>();
builder.Services.AddScoped<INhanVienRepo, NhanVienRepo>();
builder.Services.AddScoped<ISuDungDichVuRepo, SuDungDichVuRepo>();
builder.Services.AddScoped<IHinhAnhPhongService, HinhAnhPhongService>();
builder.Services.AddScoped<IWriteFileRepository, WriteFileRepository>();
builder.Services.AddScoped<ITrangThaiDatPhongRepo, TrangThaiDatPhongRepo>();
builder.Services.AddScoped<IKhachHangRepo, KhachHangRepo>();
builder.Services.AddScoped<IDatPhongRepo, DatPhongRepo>();
builder.Services.AddScoped<ISendMailService, SendEmailService>();
builder.Services.AddScoped<IForgotPasswordService, ForgotPasswordService>();
builder.Services.AddScoped<IPhuongThucThanhToanRepo, PhuongThucThanhToanRepo>();
builder.Services.AddScoped<IGiamGiaRepo, GiamGiaRepo>();
builder.Services.AddScoped<IDichVuRepo, DichVuRepo>();
builder.Services.AddScoped<IHoaDonRepo, HoaDonRepo>();
builder.Services.AddScoped<IChucVuRepo, ChucVuRepo>();
builder.Services.AddScoped<ICaLamRepo, CaLamRepo>();
builder.Services.AddScoped<IChiTietHoaDonDVRepo, ChiTietHoaDonDVRepo>();
builder.Services.AddScoped<IDoanhThuRepo, DoanhThuRepo>();

//Connection String Config
builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // xác minh chữ ký xác thực token có hợp lệ không
        ValidateAudience = false, // xác minh địa chỉ nhận
        ValidateIssuer = false, // xác minh địa chỉ gửi
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("Jwt:SecretKey").Value!)) // khóa xác thực
    };
});
// var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
// builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


