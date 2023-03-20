using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TodoListMinimalAPI.Data;
using System.Linq;
using TodoListMinimalAPI.Endpoints;
using TodoListMinimalAPI.Contracts.Response;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(); //gerencia toda a conexão com o banco, sempre que tive rum db context usa um addDbContext
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*var configAutomapper = new AutoMapper.MapperConfiguration(config =>
{
    config.CreateMap<Todo, TodoPostModel>();
});
IMapper mapper = configAutomapper.CreateMapper();
builder.Services.AddSingleton(mapper);*/

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

TodoListEndpointConfig.AddEndpoint(app);

//builder.Services.AddSingleton(TodoListEndpointConfig.AutoM());

app.Run();
