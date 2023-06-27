using BrewUp.Modules.Purchases.Infrastructure.MongoDb;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Purchases.Infrastructure;

public static class InfrastructureHelper
{
	public static IServiceCollection AddPurchasesInfrastructure(this IServiceCollection services,
		PurchasesMongoDbSettings mongoDbSettings)
	{
		services.AddPurchasesMongoDb(mongoDbSettings);

		return services;
	}
}