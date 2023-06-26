using BrewUp.Modules.Purchases.Infrastructure.MongoDb;
using BrewUp.Modules.Purchases.Infrastructure.RabbitMq;
using Muflone.Eventstore;

namespace BrewUp.Modules;

public class InfrastructureModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 10;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddMongoDb(builder.Configuration.GetSection("MongoDB").Get<MongoDbSettings>()!);
		builder.Services.AddMufloneEventStore(builder.Configuration["EventStore:ConnectionString"]!);
		builder.Services.AddRabbitMq(builder.Configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>()!);

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		return endpoints;
	}
}