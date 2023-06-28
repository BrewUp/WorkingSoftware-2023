using BrewUp.Modules.Purchases.ReadModel.Entities;

namespace BrewUp.Infrastructure.MongoDb.Readmodel;

public interface IPersister
{
	Task<T> GetBy<T>(string id) where T : EntityBase;
	Task Insert<T>(T entity) where T : EntityBase;
	Task Update<T>(T entity) where T : EntityBase;
	Task Delete<T>(T entity) where T : EntityBase;
}