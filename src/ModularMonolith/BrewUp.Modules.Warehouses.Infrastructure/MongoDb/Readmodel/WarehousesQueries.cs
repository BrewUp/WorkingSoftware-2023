﻿using BrewUp.Modules.Warehouses.ReadModel;
using BrewUp.Modules.Warehouses.ReadModel.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace BrewUp.Modules.Warehouses.Infrastructure.MongoDb.Readmodel;

public abstract class WarehousesQueries<T> : IWarehousesQueries<T> where T : EntityBase
{
	protected readonly IMongoDatabase Database;

	protected WarehousesQueries(IMongoDatabase database)
	{
		Database = database;
	}

	public async Task<T> GetByIdAsync(string id)
	{
		var collection = Database.GetCollection<T>(typeof(T).Name);
		var filter = Builders<T>.Filter.Eq("_id", id);
		return (await collection.CountDocumentsAsync(filter) > 0 ? (await collection.FindAsync(filter)).First() : null)!;
	}

	public async Task<PagedResult<T>> GetByFilterAsync(Expression<Func<T, bool>>? query, int page, int pageSize)
	{
		if (--page < 0)
			page = 0;

		var collection = Database.GetCollection<T>(typeof(T).Name);
		var queryable = query != null
			? collection.AsQueryable().Where(query)
			: collection.AsQueryable();

		var count = await queryable.CountAsync();
		var results = await queryable.Skip(page * pageSize).Take(pageSize).ToListAsync();

		return new PagedResult<T>(results, page, pageSize, count);
	}
}