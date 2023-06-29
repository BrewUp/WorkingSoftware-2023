using BrewUp.Modules.Warehouses.Sagas.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Warehouses.Sagas;

public static class WarehousesSagasHelper
{
	public static IServiceCollection AddWarehousesSagas(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BeersReceivedEventHandler).Assembly));

		return services;
	}
}