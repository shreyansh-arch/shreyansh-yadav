var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>(); // Copilot suggested error handling first
app.UseMiddleware<AuthMiddleware>();          // Copilot suggested authentication second
app.UseMiddleware<LoggingMiddleware>();       // Copilot suggested logging third

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
