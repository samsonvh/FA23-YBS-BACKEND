using System.Security.Claims;
using System.Text;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OfficeOpenXml;
using YBS.Data.Context;
using YBS.Data.UnitOfWorks;
using YBS.Data.UnitOfWorks.Implements;
using YBS.Middlewares;
using YBS.Service.Services;
using YBS.Service.Services.Implements;
using YBS.Service.Utils.AutoMapper;
using YBS.Services.Services;
using YBS.Services.Services.Implements;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<YBSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YBSContext")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();  
builder.Services.AddScoped<IYachtService, YachtService>();
builder.Services.AddScoped<IYachtTypeService, YachtTypeService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IBookingService, BookingService>();  


builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", AppContext.BaseDirectory.ToString() + @"yacht-booking-system-3bc15-firebase-adminsdk-7wvy1-bbb5e82c83.json");

//Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.FromSeconds(0)
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://localhost:3001").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMembershipPackageService, MembershipPackageService>();
builder.Services.AddScoped<IFirebaseStorageService,FirebaseStorageService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.Run();
