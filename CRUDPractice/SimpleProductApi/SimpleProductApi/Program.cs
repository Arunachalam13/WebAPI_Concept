using Microsoft.EntityFrameworkCore;
using SimpleProductApi.Db_Context;
using SimpleProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApiDocument();

builder.Services.AddSingleton<ProductService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FirstAPIContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseOpenApi();
    //app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
