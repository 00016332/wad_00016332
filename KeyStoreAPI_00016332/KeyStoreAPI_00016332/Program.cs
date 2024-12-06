using KeyStoreAPI_00016332.Data;
using KeyStoreAPI_00016332.MappingProfiles;
using KeyStoreAPI_00016332.Models;
using KeyStoreAPI_00016332.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GeneralDbContext>(o => o.UseSqlServer(
    builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Key Store Application API 16332",
        Version = "v1",
        Description = "WAD 00016332"
    });
});

builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddTransient<IRepository<KeyStore>, KeyStoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
);

app.MapControllers();

app.Run();
