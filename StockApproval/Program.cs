using ApplicationLayer;
using ApplicationLayer.Implementations.Account.VendorBill;
using ApplicationLayer.Implementations.Admin.Auth;
using ApplicationLayer.Implementations.Admin.Branch;
using ApplicationLayer.Implementations.Admin.Category;
using ApplicationLayer.Implementations.Admin.Currency;
using ApplicationLayer.Implementations.Admin.Department;
using ApplicationLayer.Implementations.Admin.Product;
using ApplicationLayer.Implementations.Admin.Purchase;
using ApplicationLayer.Implementations.Admin.Stock;
using ApplicationLayer.Implementations.Admin.User;
using ApplicationLayer.Implementations.Admin.Vendor;
using ApplicationLayer.Implementations.Director.VendorBill;
using ApplicationLayer.IRepositories.Account.VendorBill;
using ApplicationLayer.IRepositories.Admin.Auth;
using ApplicationLayer.IRepositories.Admin.Branch;
using ApplicationLayer.IRepositories.Admin.Category;
using ApplicationLayer.IRepositories.Admin.Currency;
using ApplicationLayer.IRepositories.Admin.Department;
using ApplicationLayer.IRepositories.Admin.Product;
using ApplicationLayer.IRepositories.Admin.Purchase;
using ApplicationLayer.IRepositories.Admin.Stock;
using ApplicationLayer.IRepositories.Admin.User;
using ApplicationLayer.IRepositories.Admin.Vendor;
using ApplicationLayer.IRepositories.Director.VendorBill;
using ApplicationLayer.IServices.Account.VendorBill;
using ApplicationLayer.IServices.Admin.Auth;
using ApplicationLayer.IServices.Admin.Branch;
using ApplicationLayer.IServices.Admin.Category;
using ApplicationLayer.IServices.Admin.Currency;
using ApplicationLayer.IServices.Admin.Department;
using ApplicationLayer.IServices.Admin.Email;
using ApplicationLayer.IServices.Admin.Product;
using ApplicationLayer.IServices.Admin.Purchase;
using ApplicationLayer.IServices.Admin.Stock;
using ApplicationLayer.IServices.Admin.User;
using ApplicationLayer.IServices.Admin.Vendor;
using ApplicationLayer.IServices.Director.VendorBill;
using DomainLayer.AuthDTOs;
using DomainLayer.V1.DTOs;
using InfrastructureLayer;
using InfrastructureLayer.Email.admin;
using InfrastructureLayer.Repos.V1.Account.VendorBill;
using InfrastructureLayer.Repos.V1.Admin.Auth;
using InfrastructureLayer.Repos.V1.Admin.Branch;
using InfrastructureLayer.Repos.V1.Admin.Category;
using InfrastructureLayer.Repos.V1.Admin.Currency;
using InfrastructureLayer.Repos.V1.Admin.Department;
using InfrastructureLayer.Repos.V1.Admin.Product;
using InfrastructureLayer.Repos.V1.Admin.Purchase;
using InfrastructureLayer.Repos.V1.Admin.Stock;
using InfrastructureLayer.Repos.V1.Admin.User;
using InfrastructureLayer.Repos.V1.Admin.Vendor;
using InfrastructureLayer.Repos.V1.Director.VendorBill;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StockApproval.Utilities;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register EmailSettings with IOptions
builder.Services.Configure<SmtpSetting>(builder.Configuration.GetSection("SmtpSetting"));

// Register services
RegisterServices(builder.Services);

// Add Controllers
builder.Services.AddControllers();

// API Versioning
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(
      new UrlSegmentApiVersionReader());
    //opt.ApiVersionReader = ApiVersionReader.Combine(
    //    new UrlSegmentApiVersionReader(),
    //    new HeaderApiVersionReader("x-api-version"),
    //    new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

// Swagger Configuration
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.EnableCors();

// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtOption>(jwtSettings);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            ValidateLifetime = true
        };
    });


var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Middleware Configuration
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
        options.DocumentTitle = ".NET Core (.NET 8) Web API";
        options.RoutePrefix = "swagger";
    });
}

app.Run();

// Method to register services
void RegisterServices(IServiceCollection services)
{
    services.AddHttpContextAccessor();
    services.AddSingleton<IUrlService, UrlService>();
    services.AddSingleton<IEmailServiceAdmin, EmailServiceAdmin>();

    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IAuthRepo, AuthRepo>();

    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<ICategoryRepo, CategoryRepo>();

    services.AddScoped<IVendorService, VendorService>();
    services.AddScoped<IVendorRepo, VendorRepo>();

    services.AddScoped<ICurrencyService, CurrencyService>();
    services.AddScoped<ICurrencyRepo, CurrencyRepo>();

    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IUserRepo, UserRepo>();

    services.AddScoped<IBranchService, BranchService>();
    services.AddScoped<IBranchRepo, BranchRepo>();

    services.AddScoped<IDepartmentService, DepartmentService>();
    services.AddScoped<IDepartmentRepo, DepartmentRepo>();

    services.AddScoped<IPurchaseService, PurchaseService>();
    services.AddScoped<IPurchaseRepo, PurchaseRepo>();

    services.AddScoped<IPurchaseTableService, PurchaseTableService>();
    services.AddScoped<IPurchaseTableRepo, PurchaseTableRepo>();

    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IProductRepo, ProductRepo>();

    services.AddScoped<IStockService, StockService>();
    services.AddScoped<IStockRepo, StockRepo>();

    services.AddScoped<IVendorBillService, VendorBillService>();
    services.AddScoped<IVendorBillRepo, VendorBillRepo>();

    services.AddScoped<IVendorBillTableService, VendorBillTableService>();
    services.AddScoped<IVendorBillTableRepo, VendorBillTableRepo>();

    services.AddScoped<IVendorBillAccountService, VendorBillAccountService>();
    services.AddScoped<IVendorBillAccountRepo, VendorBillAccountRepo>();

    services.AddScoped<IVendorBillTableAccountService, VendorBillTableAccountService>();
    services.AddScoped<IVendorBillTableAccountRepo, VendorBillTableAccountRepo>();
}
