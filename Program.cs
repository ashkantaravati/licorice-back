using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LicoriceBack.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LicoriceBackContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("LicoriceBackContext") ?? throw new InvalidOperationException("Connection string 'LicoriceBackContext' not found.")));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
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
