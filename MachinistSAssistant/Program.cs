using MachinistSAssistant.Data;
using MachinistSAssistant.Enpoints.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(
        "sqlite",
        builder.Configuration.GetValue<string>("Database:ConnectionString")));
builder.Services.AddEndpoints<Program>(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints<Program>();

app.Run();