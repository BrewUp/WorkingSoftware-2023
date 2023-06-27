﻿using BrewUp.Modules.Warehouses.Messages.Events;
using BrewUp.Modules.Warehouses.ReadModel.EventHandlers;
using BrewUp.Modules.Warehouses.ReadModel.Services;
using BrewUp.Modules.Warehouses.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;
using Muflone.Transport.RabbitMQ.Saga.Consumers;

namespace BrewUp.Infrastructure.RabbitMq.Events;

public sealed class BeerLoadedInStockConsumer : DomainEventsConsumerBase<BeerLoadedInStock>
{
	protected override IEnumerable<IDomainEventHandlerAsync<BeerLoadedInStock>> HandlersAsync { get; }

	public BeerLoadedInStockConsumer(IBeerService beerService, IMufloneConnectionFactory connectionFactory,
		ILoggerFactory loggerFactory) : base(connectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IDomainEventHandlerAsync<BeerLoadedInStock>>
		{
			new BeerLoadedInStockEventHandler(loggerFactory, beerService)
		};
	}
}

public sealed class BeerLoadedInStockSagaConsumer : SagaEventConsumerBase<BeerLoadedInStock>
{
	public BeerLoadedInStockSagaConsumer(IServiceBus serviceBus, ISagaRepository sagaRepository, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
		: base(connectionFactory, loggerFactory)
	{
		HandlerAsync = new BeersReceivedSaga(serviceBus, sagaRepository, loggerFactory);
	}

	protected override ISagaEventHandlerAsync<BeerLoadedInStock> HandlerAsync { get; }
}