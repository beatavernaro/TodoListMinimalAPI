using Microsoft.EntityFrameworkCore;
using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Endpoints;
using TodoListMinimalAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskAPIContext") ?? throw new InvalidOperationException("Connection string 'TaskAPIContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(TaskMapper));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

TaskListEndpointConfig.AddEndpoint(app);


app.Run();
