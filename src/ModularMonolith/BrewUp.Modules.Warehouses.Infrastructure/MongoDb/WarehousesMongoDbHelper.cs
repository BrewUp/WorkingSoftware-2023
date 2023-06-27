using BrewUp.Modules.Warehouses.Infrastructure.MongoDb.Readmodel;
using BrewUp.Modules.Warehouses.ReadModel;
using BrewUp.Modules.Warehouses.ReadModel.Entities;
using BrewUp.Modules.Warehouses.ReadModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Muflone.Eventstore.Persistence;

namespace BrewUp.Modules.Warehouses.Infrastructure.MongoDb;

public static class WarehousesMongoDbHelper
{
	public static IServiceCollection AddWarehousesMongoDb(this IServiceCollection services,
		WarehousesMongoDbSettings mongoDbSettings)
	{
		services.AddSingleton<IMongoDatabase>(x =>
		{
			var client = new MongoClient(mongoDbSettings.ConnectionString);
			var database = client.GetDatabase(mongoDbSettings.DatabaseName);
			return database;
		});
		services.AddScoped<IWarehousesPersister, WarehousesPersister>();
		services.AddScoped<IWarehousesQueries<Beer>, BeersQueries>();
		services.AddScoped<IWarehouseAvailabilityService, WarehouseAvailabilityService>();
		services.AddScoped<IBeerService, BeerService>();

		services.AddSingleton<IEventStorePositionRepository>(x =>
			new EventStorePositionRepository(x.GetService<ILogger<EventStorePositionRepository>>(), mongoDbSettings));

		return services;
	}
}