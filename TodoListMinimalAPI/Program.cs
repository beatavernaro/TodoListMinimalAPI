using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Endpoints;
using AutoMapper;
using TodoListMinimalAPI.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskAPIContext") ?? throw new InvalidOperationException("Connection string 'TaskAPIContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(TaskMapper));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

TaskListEndpointConfig.AddEndpoint(app);


app.Run();
