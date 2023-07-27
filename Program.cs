using Microsoft.SemanticKernel;
using SearchKernelProject.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<OpenAPI>(builder.Configuration.GetSection("OpenAPI"));

//var openApi = builder.Configuration.GetSection("OpenAPI").Get<OpenAPI>();
//var kernel = Kernel.Builder
//    .WithOpenAITextCompletionService(openApi.ChatModel, openApi.OpenApiKey)
//    .Build();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
