using BackendApg.Business;
using BackendApg.Data;

var builder = WebApplication.CreateBuilder(args);

// Dependencies injection

builder.Services.AddSingleton<ISqlMockRepository, SqlMockRepository>();
builder.Services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();

//CORS enabled for development purposes

builder.Services.AddCors(opt => {
    opt.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
