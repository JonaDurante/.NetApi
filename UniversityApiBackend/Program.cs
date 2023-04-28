// 1. Using para trabajar con EF
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAcces;
 
var builder = WebApplication.CreateBuilder(args);

// 2. agregar conexion a base de datos
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
// 3. Add Context to Services of builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();

// 4. Add Custom Services (folder services)
// builder.Services.AddScoped<IStuden, Student>();   --->cambiar

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. Cors Configuration
builder.Services.AddCors(options => 
{
    options.AddPolicy(name: "CorsPollicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader(); // Ré generica, modificar
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 6. Tell app to use CORS
app.UseCors("CorsPollicy");

app.Run();
