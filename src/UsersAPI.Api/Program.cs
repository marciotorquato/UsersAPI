using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<UsersApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsersApiConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
