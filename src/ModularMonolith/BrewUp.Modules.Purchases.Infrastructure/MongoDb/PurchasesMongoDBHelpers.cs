using BrewUp.Modules.Purchases.Infrastructure.MongoDb.Readmodel;
using BrewUp.Modules.Purchases.ReadModel;
using BrewUp.Modules.Purchases.ReadModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Muflone.Eventstore.Persistence;

namespace BrewUp.Modules.Purchases.Infrastructure.MongoDb
{
	public static class PurchasesMongoDbHelpers
	{
		public static IServiceCollection AddPurchasesMongoDb(this IServiceCollection services,
			PurchasesMongoDbSettings mongoDbSettings)
		{
			services.AddSingleton(x =>
			{
				BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

				var client = new MongoClient(mongoDbSettings.ConnectionString);
				var database = client.GetDatabase(mongoDbSettings.DatabaseName);
				return database;
			});
			services.AddScoped<IPurchasesPersister, PurchasesPersister>();
			services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
			services.AddSingleton<IEventStorePositionRepository>(x =>
				new EventStorePositionRepository(x.GetService<ILogger<EventStorePositionRepository>>(), mongoDbSettings));

			return services;
		}
	}
}
