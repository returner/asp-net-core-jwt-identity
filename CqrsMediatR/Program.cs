using CqrsMediatR.Behaviors;
using CqrsMediatR.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// mediatR
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddSingleton<ISampleDataStore, SampleDataStore>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggerBehavior<,>));

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
