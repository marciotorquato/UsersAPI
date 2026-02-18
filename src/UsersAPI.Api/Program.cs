using Microsoft.EntityFrameworkCore;
using Serilog;
using UsersAPI.Api.Endpoints;
using UsersAPI.Api.Middleware;
using UsersAPI.Data;
using UsersAPI.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuthenticationConfig(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddControllers();
builder.AddSerilogConfiguration();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<UsersApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MS_UserAPI")));
builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddRepositories();
builder.Services.AddAuthenticationDependencies(builder.Configuration);
builder.Host.UseSerilog();

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
app.MapAuthentication();
app.MapContatos();
app.MapEnderecos();
app.MapRoles();
app.MapUsuarioPerfil();
app.MapUsuarioRole();
app.MapUsuarios();

app.Run();