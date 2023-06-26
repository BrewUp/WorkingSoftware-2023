using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Warehouses;

public static class WarehousesHelper
{
	public static IServiceCollection AddWarehouses(this IServiceCollection services)
	{
		return services;
	}
}