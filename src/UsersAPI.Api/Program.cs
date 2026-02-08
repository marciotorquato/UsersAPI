using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuthenticationConfig(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddControllers();
builder.AddSerilogConfiguration();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<UsersApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UsersApiConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseSerilogRequestLoggingConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
