using FinancasApp.Domain.Interfaces.Messages;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using FinancasApp.infra.Messages.Consumers;
using FinancasApp.Infra.Data.Repositories;
using FinancasApp.Infra.Messages.Producers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuração de injeções de dependência
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<IMovimentacaoService, MovimentacaoService>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddTransient<IMessageProducer, RabbitMQProducer>(); // a segunda é a classe que implementa a interface


//Ativar o Consumer da mensageria
builder.Services.AddHostedService<RabbitMQConsumer>();

//Configuração para permitir que quaisquer aplicações
//façam requisições para a nossa API
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", policy =>
    {
        policy.AllowAnyOrigin() //permissão para qualquer origem
              .AllowAnyMethod() //permissão para qualquer método HTTP
              .AllowAnyHeader(); //permissão para qualquer cabeçalho
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Cors
app.UseCors("DefaultPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
