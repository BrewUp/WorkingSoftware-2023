﻿using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Modules.Warehouses.Messages.Commands;

public sealed class CreateBeer : Command
{
	public readonly BeerId BeerId;
	public readonly BeerName BeerName;

	public CreateBeer(BeerId aggregateId, Guid commitId, BeerName beerName) : base(aggregateId, commitId)
	{
		BeerId = aggregateId;
		BeerName = beerName;
	}
}