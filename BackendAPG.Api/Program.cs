using BackendApg.Business;
using BackendApg.Data;

var builder = WebApplication.CreateBuilder(args);

// Dependencies injection

builder.Services.AddSingleton<ISqlMockRepository, SqlMockRepository>();
builder.Services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
