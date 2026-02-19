using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Api.Models.Examples.Validation;
using NetworkMonitor.Domain;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<HostInformationDtoExample>();
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("myDb")));

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
