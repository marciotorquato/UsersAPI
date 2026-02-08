using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerDocumentation();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<UsersApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UsersApiConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
