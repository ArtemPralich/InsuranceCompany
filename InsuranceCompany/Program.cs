using InsuranceCompany.Core;
//using InsuranceCompany.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InsuranceCompanyContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), b =>
    b.MigrationsAssembly("InsuranceCompany.Core")));

//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
