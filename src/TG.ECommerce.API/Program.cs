using TG.ECommerce.API.Extensions;
using TG.ECommerce.API.Services;
using TG.ECommerce.Infrastructure.EFCore;
using TG.ECommerce.Shared.Settings;

var builder = WebApplication.CreateBuilder(args);

#region Application settings
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddSingleton<VaultService>();

// Settings'leri Vault'tan Configure et
builder.Services.ConfigureFromVault<DatabaseSettings>(builder.Configuration, "DatabaseSettings");
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Add Layers
builder.Services.AddInfrastructureEfCore();
#endregion

builder.Services.AddSwaggerGen();

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
