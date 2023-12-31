﻿using BrewUp.Modules.Warehouses.Domain.CommandHandlers;
using BrewUp.Modules.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Infrastructure.RabbitMq.Commands;

public sealed class LoadBeerInStockConsumer : CommandConsumerBase<LoadBeerInStock>
{
	protected override ICommandHandlerAsync<LoadBeerInStock> HandlerAsync { get; }

	public LoadBeerInStockConsumer(IRepository repository,
		IMufloneConnectionFactory connectionFactory,
		ILoggerFactory loggerFactory) : base(repository, connectionFactory, loggerFactory)
	{
		HandlerAsync = new LoadBeerInStockCommandHandler(repository, loggerFactory);
	}
}