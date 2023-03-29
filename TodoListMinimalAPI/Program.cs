using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(); //gerencia toda a conexão com o banco, sempre que tive rum db context usa um addDbContext
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

TodoListEndpointConfig.AddEndpoint(app);


app.Run();
