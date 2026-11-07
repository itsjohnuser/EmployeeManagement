using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.service;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<EmployeeManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagementContext")));
builder.Services.AddScoped<IEmployeeservice, Employeeservice>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
