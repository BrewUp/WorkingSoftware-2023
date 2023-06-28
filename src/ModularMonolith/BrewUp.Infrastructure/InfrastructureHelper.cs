using BrewUp.Infrastructure.MongoDb;
using BrewUp.Infrastructure.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Eventstore;

namespace BrewUp.Infrastructure;

public static class InfrastructureHelper
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		string evenStoreConnectionString,
		RabbitMqSettings rabbitMqSettings,
		MongoDbSettings mongoDbSettings)
	{
		services.AddMufloneEventStore(evenStoreConnectionString);
		services.AddRabbitMq(rabbitMqSettings);
		services.AddMongoDb(mongoDbSettings);

		return services;
	}
}