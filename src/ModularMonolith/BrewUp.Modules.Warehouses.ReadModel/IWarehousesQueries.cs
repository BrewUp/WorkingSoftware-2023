using BrewUp.Modules.Warehouses.ReadModel.Entities;
using System.Linq.Expressions;

namespace BrewUp.Modules.Warehouses.ReadModel;

public interface IWarehousesQueries<T> where T : EntityBase
{
	Task<T> GetByIdAsync(string id);
	Task<PagedResult<T>> GetByFilterAsync(Expression<Func<T, bool>>? query, int page, int pageSize);
}