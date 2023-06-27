using BrewUp.Infrastructure;
using BrewUp.Infrastructure.RabbitMq;
using BrewUp.Modules.Purchases.Infrastructure;
using BrewUp.Modules.Purchases.Infrastructure.MongoDb;
using BrewUp.Modules.Warehouses.Infrastructure;
using BrewUp.Modules.Warehouses.Infrastructure.MongoDb;

namespace BrewUp.Modules;

public class InfrastructureModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 10;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddPurchasesInfrastructure(builder.Configuration.GetSection("BrewUp:Purchases:MongoDB").Get<PurchasesMongoDbSettings>()!);
		builder.Services.AddWarehousesInfrastructure(builder.Configuration.GetSection("BrewUp:Warehouses:MongoDB").Get<WarehousesMongoDbSettings>()!);

		builder.Services.AddInfrastructure(builder.Configuration["BrewUp:EventStore:ConnectionString"]!,
			builder.Configuration.GetSection("BrewUp:RabbitMQ").Get<RabbitMqSettings>()!);

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}