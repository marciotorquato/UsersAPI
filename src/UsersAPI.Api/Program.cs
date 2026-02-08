using Microsoft.EntityFrameworkCore;
using UsersAPI.Api.Middleware;
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

app.UseMiddleware<LoggingMiddleware>();
app.UseSerilogRequestLoggingConfiguration();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();


app.Run();