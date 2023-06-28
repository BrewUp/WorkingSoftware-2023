using BrewUp.Infrastructure;
using BrewUp.Infrastructure.MongoDb;
using BrewUp.Infrastructure.RabbitMq;

namespace BrewUp.Modules;

public class InfrastructureModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 10;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddInfrastructure(builder.Configuration["BrewUp:EventStore:ConnectionString"]!,
			builder.Configuration.GetSection("BrewUp:RabbitMQ").Get<RabbitMqSettings>()!,
			builder.Configuration.GetSection("BrewUp:MongoDB").Get<MongoDbSettings>()!);

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}