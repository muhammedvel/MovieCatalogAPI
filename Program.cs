using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); 
builder.Services.AddControllers(); 

// ДОБАВЕНО: Разрешаваме CORS (комуникацията с браузъри)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ДОБАВЕНО: Активираме CORS политиката, която създадохме горе
app.UseCors("AllowAll");

app.MapControllers(); 

app.MapGet("/", () => "Movie Catalog API is connected to PostgreSQL!");

app.Run();