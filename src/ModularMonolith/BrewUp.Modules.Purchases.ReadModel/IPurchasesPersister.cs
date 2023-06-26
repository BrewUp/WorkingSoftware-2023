using BrewUp.Modules.Purchases.ReadModel.Entities;

namespace BrewUp.Modules.Purchases.ReadModel
{
	public interface IPurchasesPersister
	{
		Task<T> GetBy<T>(string id) where T : EntityBase;
		Task Insert<T>(T entity) where T : EntityBase;
		Task Update<T>(T entity) where T : EntityBase;
		Task Delete<T>(T entity) where T : EntityBase;
	}
}