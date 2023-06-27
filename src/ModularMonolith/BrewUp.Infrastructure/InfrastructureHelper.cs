using BrewUp.Infrastructure.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Eventstore;

namespace BrewUp.Infrastructure;

public static class InfrastructureHelper
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		string evenStoreConnectionString,
		RabbitMqSettings rabbitMqSettings)
	{
		services.AddMufloneEventStore(evenStoreConnectionString);
		services.AddRabbitMq(rabbitMqSettings);

		return services;
	}
}