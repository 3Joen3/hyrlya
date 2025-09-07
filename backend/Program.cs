using HyrLya.Infrastructure;
using HyrLya.Extensions;

var builder = WebApplication.CreateBuilder(args);

AddFrontendPolicy(builder);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseCors("Frontend");

app.UseHttpsRedirection();

app.MapIdentityApi<User>();
app.MapControllers();

app.Run();

static void AddFrontendPolicy(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Frontend", policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });
}
