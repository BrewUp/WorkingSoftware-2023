﻿using BrewUp.Modules.Warehouses.ReadModel;
using BrewUp.Modules.Warehouses.ReadModel.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace BrewUp.Modules.Warehouses.Infrastructure.MongoDb.Readmodel;

public sealed class BeersQueries : IWarehousesQueries<Beer>
{
	private readonly IMongoDatabase _database;

	public BeersQueries(IMongoDatabase database)
	{
		_database = database;
	}

	public async Task<Beer> GetByIdAsync(string id)
	{
		var collection = _database.GetCollection<Beer>(nameof(Beer));
		var filter = Builders<Beer>.Filter.Eq("_id", id);
		return (await collection.CountDocumentsAsync(filter) > 0 ? (await collection.FindAsync(filter)).First() : null)!;
	}

	public async Task<PagedResult<Beer>> GetByFilterAsync(Expression<Func<Beer, bool>>? query, int page, int pageSize)
	{
		if (--page < 0)
			page = 0;

		var collection = _database.GetCollection<Beer>(nameof(Beer));
		var queryable = query != null
			? collection.AsQueryable().Where(query)
			: collection.AsQueryable();

		var count = await queryable.CountAsync();
		var results = await queryable.Skip(page * pageSize).Take(pageSize).ToListAsync();

		return new PagedResult<Beer>(results, page, pageSize, count);
	}
}