using BrewUp.Modules.Warehouses.Sagas;

namespace BrewUp.Modules;

public class WarehousesModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 0;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddWarehousesSagas();

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		return endpoints;
	}
}