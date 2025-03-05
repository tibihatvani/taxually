using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Factories;
using Taxually.TechnicalTest.RegistrationStrategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<ITaxuallyHttpClient, TaxuallyHttpClient>()
    .AddScoped<ITaxuallyQueueClient, TaxuallyQueueClient>()

    .AddScoped<IVatRegistrationStrategyFactory, VatRegistrationStrategyFactory>()
    .AddTransient<IVatRegistrationStrategy, UKVatRegistrationStrategy>()
    .AddTransient<IVatRegistrationStrategy, FRVatRegistrationStrategy>()
    .AddTransient<IVatRegistrationStrategy, DEVatRegistrationStrategy>();

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
