using Microsoft.Extensions.Logging;

namespace BrewUp.Modules.Purchases.ReadModel.Services;

public abstract class ServiceBase
{
	protected readonly IPurchasesPersister Persister;
	protected readonly ILogger Logger;

	protected ServiceBase(ILoggerFactory loggerFactory, IPurchasesPersister persister)
	{
		Persister = persister;
		Logger = loggerFactory.CreateLogger(GetType());
	}
}