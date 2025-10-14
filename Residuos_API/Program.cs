using Microsoft.EntityFrameworkCore;
using RecyclingManagementAPI.Data;
using RecyclingManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Configurar o DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar o Service
builder.Services.AddScoped<CollectionPointService>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativar Swagger sempre, independente do ambiente
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

// NECESSÁRIO PARA TESTES COM WebApplicationFactory
public partial class Program { }