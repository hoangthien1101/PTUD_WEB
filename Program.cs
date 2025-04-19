using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using webAPI.Data;
using MyWebApi.Services;
using MyWebApi.Service;
using MyWebApi.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Cho phép đọc từ biến môi trường khi deploy trên Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Nhập JWT token vào đây",

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

// Register các service phụ thuộc
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

// Cấu hình kết nối database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình JWT
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!))
    };
});

var app = builder.Build();

// Luôn bật Swagger nếu được cấu hình hoặc môi trường là Development
if (builder.Configuration.GetValue<bool>("EnableSwagger") || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
