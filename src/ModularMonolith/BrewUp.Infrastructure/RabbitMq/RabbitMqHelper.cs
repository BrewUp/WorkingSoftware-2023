using BrewUp.Infrastructure.RabbitMq.Commands;
using BrewUp.Infrastructure.RabbitMq.Events;
using BrewUp.Modules.Purchases.ReadModel.Services;
using BrewUp.Modules.Warehouses.ReadModel.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Persistence;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Factories;
using Muflone.Transport.RabbitMQ.Models;

namespace BrewUp.Infrastructure.RabbitMq;

public static class RabbitMqHelper
{
	public static IServiceCollection AddRabbitMq(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
	{
		var serviceProvider = services.BuildServiceProvider();
		var repository = serviceProvider.GetRequiredService<IRepository>();
		var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

		var configuration = new RabbitMQConfiguration(rabbitMqSettings.Host, rabbitMqSettings.Username,
			rabbitMqSettings.Password, rabbitMqSettings.ExchangeCommandName, rabbitMqSettings.ExchangeEventName);
		var connectionFactory = new MufloneConnectionFactory(configuration, loggerFactory);

		services.AddMufloneTransportRabbitMQ(loggerFactory, configuration);

		//It's important to build the previous services registrations or IEventBus and IPurchaseOrderService will be null 
		//We need to improve this part. It's awful like it is right now
		serviceProvider = services.BuildServiceProvider();
		services.AddMufloneRabbitMQConsumers(new List<IConsumer>
		{
			#region Purchases
			new CreatePurchaseOrderConsumer(repository, connectionFactory, loggerFactory),
			new ChangePurchaseOrderStatusToCompleteConsumer(repository, connectionFactory, loggerFactory),
			new PurchaseOrderCreatedConsumer(serviceProvider.GetRequiredService<IPurchaseOrderService>(), connectionFactory, loggerFactory),
			new PurchaseOrderStatusChangedToCompleteConsumer(serviceProvider.GetRequiredService<IEventBus>(), serviceProvider.GetRequiredService<IPurchaseOrderService>(), connectionFactory, loggerFactory),
			#endregion

			#region Warehouses
			new BeersReceivedConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
			connectionFactory,
			loggerFactory),

			new CreateBeerConsumer(repository!, connectionFactory,
				loggerFactory),

			new BeerCreatedConsumer(serviceProvider.GetRequiredService<IBeerService>(),
				connectionFactory,
				loggerFactory),

			new LoadBeerInStockConsumer(repository!, connectionFactory,
				loggerFactory),

			new BeerLoadedInStockConsumer(serviceProvider.GetRequiredService<IBeerService>(),
				connectionFactory,
				loggerFactory),

			new StartBeersReceivedSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
				serviceProvider.GetRequiredService<ISagaRepository>(),
				repository!,
				connectionFactory,
				loggerFactory),

			new BeerCreatedSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
				serviceProvider.GetRequiredService<ISagaRepository>(),
				connectionFactory,
				loggerFactory),

			new BeerLoadedInStockSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(),
				serviceProvider.GetRequiredService<ISagaRepository>(),
				connectionFactory,
				loggerFactory)
		#endregion
		});

		return services;
	}
}