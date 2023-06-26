using BrewUp.Modules.Purchases.ReadModel.Entities;
using System.Linq.Expressions;

namespace BrewUp.Modules.Purchases.ReadModel
{
	public interface IPurchasesQueries<T> where T : EntityBase
	{
		Task<T> GetById(string id);
		Task<PagedResult<T>> GetByFilter(Expression<Func<T, bool>> query, int page, int pageSize);
	}
}
