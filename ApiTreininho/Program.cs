using System.Collections;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var eu = new Dados("Thales", 21, 74.0, "Sistemas de informação", "5 semestre");
var helloMessage = new Mensagem("Hello World"); // Renomeie a variável "mensagem" para "helloMessage"

var sobreMim = new ArrayList();
sobreMim.Add(helloMessage); // Use a variável renomeada "helloMessage"
sobreMim.Add(eu);

app.MapGet("Caipirinha", () => Results.Json(sobreMim));

app.Run();

public record Dados(string Nome, int Idade, double Peso, string Curso, string Periodo);
public record Mensagem(string mensagem);
