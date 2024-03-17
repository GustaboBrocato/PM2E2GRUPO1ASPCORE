using Microsoft.EntityFrameworkCore;
using PM2E2GRUPO1ASPCORE.Data;
using PM2E2GRUPO1ASPCORE.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexion de la base de datos
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<SitiosDB>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
// Comentar linea porque en server en linea swagger no funciona
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ENDPOINTS
//Create
app.MapPost("/sitios/", async (Sitio s, SitiosDB db) =>
{
    db.Sitios.Add(s);
    await db.SaveChangesAsync();

    return Results.Ok(true);
});

//Get
app.MapGet("/sitios/{id:int}", async (int id, SitiosDB db) =>
{
    return await db.Sitios.FindAsync(id)
    is Sitio s
    ? Results.Ok(s)
    : Results.NotFound();
});

//Get All
app.MapGet("/sitios", async (SitiosDB db) => await db.Sitios.ToListAsync());

//Update
app.MapPut("/sitios/{id:int}", async (int id, Sitio s, SitiosDB db) =>
{
    if (s.Id != id)
    {
        return Results.BadRequest();
    }

    var sitio = await db.Sitios.FindAsync(id);

    if (sitio is null) return Results.NotFound();

    sitio.Descripcion = s.Descripcion;
    sitio.Latitud = s.Latitud;
    sitio.Longitud = s.Longitud;
    sitio.VideoDigital = s.VideoDigital;
    sitio.AudioFile = s.AudioFile;

    await db.SaveChangesAsync();

    return Results.Ok(sitio);

});

app.MapDelete("/sitios/{id:int}", async (int id, SitiosDB db) =>
{
    var sitio = await db.Sitios.FindAsync(id);

    if (sitio is null) return Results.NotFound();
    
    db.Sitios.Remove(sitio);
    await db.SaveChangesAsync();
    
    return Results.NoContent();
});

app.Run();