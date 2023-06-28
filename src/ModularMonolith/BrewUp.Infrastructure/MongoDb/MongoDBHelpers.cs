using BrewUp.Infrastructure.MongoDb.Readmodel;
using BrewUp.Modules.Purchases.ReadModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Muflone.Eventstore.Persistence;

namespace BrewUp.Infrastructure.MongoDb
{
	public static class MongoDBHelpers
	{
		public static IServiceCollection AddMongoDb(this IServiceCollection services,
			MongoDbSettings mongoDbSettings)
		{
			services.AddSingleton(x =>
			{
				BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

				var client = new MongoClient(mongoDbSettings.ConnectionString);
				var database = client.GetDatabase(mongoDbSettings.DatabaseName);
				return database;
			});
			services.AddScoped<IPersister, Persister>();
			services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
			services.AddSingleton<IEventStorePositionRepository>(x =>
				new EventStorePositionRepository(x.GetService<ILogger<EventStorePositionRepository>>(), mongoDbSettings));

			return services;
		}
	}
}
