using BrewUp.Modules.Purchases.ReadModel;
using BrewUp.Modules.Purchases.ReadModel.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace BrewUp.Modules.Purchases.Infrastructure.MongoDb.Readmodel;

public abstract class PurchasesQueries<T> : IPurchasesQueries<T> where T : EntityBase
{
	protected readonly IMongoDatabase Database;

	protected PurchasesQueries(IMongoDatabase database)
	{
		Database = database;
	}

	public async Task<T> GetById(string id)
	{
		var collection = Database.GetCollection<T>(typeof(T).Name);
		var filter = Builders<T>.Filter.Eq("_id", id);
		return (await collection.CountDocumentsAsync(filter) > 0 ? (await collection.FindAsync(filter)).First() : null)!;
	}

	public async Task<PagedResult<T>> GetByFilter(Expression<Func<T, bool>> query, int page, int pageSize)
	{
		//TODO a minimum errors handling would be nice in real life
		if (--page < 0)
			page = 0;
		var collection = Database.GetCollection<T>(typeof(T).Name);
		var count = await collection.AsQueryable().Where(query).CountAsync();
		var results = await collection.AsQueryable().Where(query).Skip(page * pageSize).Take(pageSize).ToListAsync();
		return new PagedResult<T>(results, page, pageSize, count);
	}
}