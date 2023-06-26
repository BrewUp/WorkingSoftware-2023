﻿using Brewup.Purchases.Domain.CommandHandlers;
using Brewup.Purchases.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace Brewup.Purchases.Infrastructure.RabbitMq.Commands;

public sealed class CreatePurchaseOrderConsumer : CommandConsumerBase<CreatePurchaseOrder>
{
	protected override ICommandHandlerAsync<CreatePurchaseOrder> HandlerAsync { get; }

	public CreatePurchaseOrderConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
		: base(repository, connectionFactory, loggerFactory)
	{
		HandlerAsync = new CreatePurchaseOrderHandlerAsync(repository, loggerFactory);
	}
}