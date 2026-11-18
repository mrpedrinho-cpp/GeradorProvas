using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos Controllers
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositórios
builder.Services.AddSingleton<IRepositorioQuestoes, RepositorioQuestoesEmMemoria>();
builder.Services.AddSingleton<IRepositorioProvas, RepositorioProvasEmMemoria>();

// Gerador aleatório
builder.Services.AddSingleton(Random.Shared);
builder.Services.AddScoped<IEmbaralhador, EmbaralhadorAleatorio>();

// Serviços de aplicação
builder.Services.AddScoped<ServicoCadastroQuestao>();
builder.Services.AddScoped<ServicoConsultaQuestao>();
builder.Services.AddScoped<ServicoGeradorProva>();
builder.Services.AddScoped<ServicoConsultaProva>();

var app = builder.Build();

// Habilita o Swagger durante o desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();