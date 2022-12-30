using backend.Controllers;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

var AllowSpecificOrigins = "_allowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                  policy =>
                  {
                      policy.WithOrigins("http://localhost:5173",
                                        "http://localhost")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();
                  });
});

// Add services to the container.

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

// Creando un contexto por cada tabla.

builder.Services.AddDbContext<MatchamkingContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion);
});

builder.Services.AddScoped<IJugadorServices, JugadorServices>();
builder.Services.AddScoped<IPartidoServices, PartidoServices>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
