using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
//using YourNamespace.Data; // Adicione o namespace correto para o SistemaEventosContext

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<MongoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SistemaEventosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS para permitir acesso do frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

// Use CORS antes dos controllers
app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
