using TrainingApi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Passando a configuração para o DbContext
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"), 
    sqlServerOptions => 
    {
        sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Número máximo de tentativas
            maxRetryDelay: TimeSpan.FromSeconds(30), // Atraso máximo entre tentativas
            errorNumbersToAdd: null // Especificar quais erros devem acionar a repetição
        );
    }));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
