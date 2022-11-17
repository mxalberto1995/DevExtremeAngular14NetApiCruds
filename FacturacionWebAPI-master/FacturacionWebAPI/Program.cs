using Facturacion.DAL;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

string CorsConfig = "_corsConfiguration";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtenemos la cadena de conexion del archivo de configuración
string connStr = builder.Configuration.GetConnectionString("cnFacturacion");


// Agregamos la inyección de dependencias de la conexion a SQL Server para BD
builder.Services.AddSqlServer<FacturacionDBContext>(connStr);

var origins = builder.Configuration.GetSection("CorsAcceptedOrigins").Get<List<string>>();
builder.Services.AddCors(options => options.AddPolicy(name: CorsConfig, policy =>
{
    foreach (string origin in origins)
    {
        policy.WithOrigins(origin)
            .AllowAnyHeader()
            .AllowAnyMethod();
    }
}));

var app = builder.Build();

// Ejecutar la migracion para que se acualice o cree la BD
// En la consola del administrador de paquetes, seleccionando el DAL como predeterminado
// ejecuta la siguiente linea para crear la primera migracion
// Add-Migration InitialDB
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<FacturacionDBContext>();
    ctx.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsConfig);

app.UseAuthorization();

app.MapControllers();

app.Run();
