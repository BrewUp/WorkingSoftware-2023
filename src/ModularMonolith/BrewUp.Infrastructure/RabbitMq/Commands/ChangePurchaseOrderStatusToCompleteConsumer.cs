﻿using BrewUp.Modules.Purchases.Domain.CommandHandlers;
using BrewUp.Modules.Purchases.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Infrastructure.RabbitMq.Commands;

public sealed class ChangePurchaseOrderStatusToCompleteConsumer : CommandConsumerBase<ChangePurchaseOrderStatusToComplete>
{
	protected override ICommandHandlerAsync<ChangePurchaseOrderStatusToComplete> HandlerAsync { get; }

	public ChangePurchaseOrderStatusToCompleteConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
		: base(repository, connectionFactory, loggerFactory)
	{
		HandlerAsync = new ChangePurchaseOrderStatusToCompleteHandlerAsync(repository, loggerFactory);
	}
}