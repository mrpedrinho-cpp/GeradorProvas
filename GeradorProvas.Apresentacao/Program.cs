
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos Controllers
builder.Services.AddControllers();

// Repositórios
builder.Services.AddSingleton<
    IRepositorioQuestoes,
    RepositorioQuestoesEmMemoria>();

builder.Services.AddSingleton<
    IRepositorioProvas,
    RepositorioProvasEmMemoria>();

// Gerador aleatório
builder.Services.AddSingleton(Random.Shared);

builder.Services.AddScoped<
    IEmbaralhador,
    EmbaralhadorAleatorio>();

// Serviços de aplicação
builder.Services.AddScoped<ServicoCadastroQuestao>();
builder.Services.AddScoped<ServicoConsultaQuestao>();
builder.Services.AddScoped<ServicoGeradorProva>();
builder.Services.AddScoped<ServicoConsultaProva>();

// Construção da aplicação
var app = builder.Build();

// Configuração dos endpoints
app.MapControllers();

app.Run();