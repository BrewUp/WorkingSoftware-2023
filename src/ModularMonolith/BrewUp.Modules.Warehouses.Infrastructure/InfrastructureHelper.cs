using BrewUp.Modules.Warehouses.Infrastructure.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Saga.Persistence.MongoDb;

namespace BrewUp.Modules.Warehouses.Infrastructure;

public static class InfrastructureHelper
{
	public static IServiceCollection AddWarehousesInfrastructure(this IServiceCollection services,
		WarehousesMongoDbSettings mongoDbSettings)
	{
		services.AddWarehousesMongoDb(mongoDbSettings);
		services.AddMongoSagaStateRepository(new MongoSagaStateRepositoryOptions(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName));

		return services;
	}
}