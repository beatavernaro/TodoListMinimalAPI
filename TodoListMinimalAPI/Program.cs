using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Endpoints;
using AutoMapper;
using TodoListMinimalAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(); //gerencia toda a conexão com o banco, sempre que tive rum db context usa um addDbContext
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(TaskMapper));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

TaskListEndpointConfig.AddEndpoint(app);


app.Run();
