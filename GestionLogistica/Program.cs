using GestionLogistica.Abstraction.DBContext;
using GestionLogistica.DataAccess;
using Gestionlogistica.Repository.CodificacionRespuesta;
using GestionLogistica.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Gestionlogistica.Repository.Dominio;
using GestionLogistica.BAL;
using GestionLogistica.BAL.Dominio;
using Serilog;
using GestionLogistica.Global.Exceptions;

var builder = WebApplication.CreateBuilder(args);

/*Definicion de la configuracion para CORS*/

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                            .AllowAnyHeader()
                            .WithMethods("POST", "GET", "PUT", "DELETE")
                            .WithOrigins("http://localhost:5275")// Parametrizar
                            .AllowCredentials();
                      });
});

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
    config.Enrich.FromLogContext();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/*Definición del String de conexion a la Base de Datos*/
var connectionString = builder.Configuration.GetConnectionString("DBCadenaGestionLogistica");
builder.Services.AddDbContext<APIDBContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BaseAPI.Rest")));

/*Definicion de la configuracion para JWT*/
builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options =>
{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(jwt =>
{
    var jwtconf = builder.Configuration.GetSection("JwtConfig").Get<JWTConfig>();
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTKey"]);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = true,
    };
});





builder.Services.AddScoped(typeof(TerrestreRepository<>), typeof(TerrestreRepository<>));
builder.Services.AddScoped(typeof(MaritimaRepository<>), typeof(MaritimaRepository<>));

builder.Services.AddScoped(typeof(TerrestreBAL<>), typeof(TerrestreBAL<>));
builder.Services.AddScoped(typeof(MaritimaBAL<>), typeof(MaritimaBAL<>));

builder.Services.AddScoped(typeof(AutentificadorBAL), typeof(AutentificadorBAL));

builder.Services.AddScoped(typeof(RespuestaRepository<>), typeof(RespuestaRepository<>));
builder.Services.AddScoped(typeof(IDBContext<>), typeof(DBContext<>));
builder.Services.AddScoped(typeof(APIDBContext), typeof(APIDBContext));
builder.Services.AddScoped(typeof(ITokenHandlerService), typeof(TokenHandlerService));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();