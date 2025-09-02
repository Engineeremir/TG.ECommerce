using TG.ECommerce.API.SeedWork.ExceptionHandling;
using TG.ECommerce.API.Services;
using TG.ECommerce.Application;
using TG.ECommerce.Infrastructure.EFCore;

var builder = WebApplication.CreateBuilder(args);

#region Application settings
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var vaultService = new VaultService(builder.Configuration);
vaultService.SetSecrets();

builder.Configuration
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Add Layers
builder.Services.AddInfrastructureEfCore(builder.Configuration);
builder.Services.AddApplication();
#endregion


#region Problem Details
builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
builder.Services.AddExceptionHandler<DomainExceptionHandler>();
builder.Services.AddExceptionHandler<FluentValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandnler>();
builder.Services.AddProblemDetails();
#endregion


builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseExceptionHandler();
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
