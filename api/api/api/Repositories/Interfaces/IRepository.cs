using System.Linq.Expressions;
using api.Models.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace api.Repositories.Interfaces;

public interface IRepository<T, K> where T : class, IBaseEntity, new() where K : struct
{
	Task<T> AddAsync(T entity);
	Task<T> UpdateAsync(T entity);

	T? Find(
		Expression<Func<T, T>>? selector = null,
		Expression<Func<T, bool>>? predicate = null,
		Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
		Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
		bool disableTracking = true,
		bool ignoreQueryFilters = false);

	bool SoftDelete(T entity);
	T? FindById(K id);

	List<T> GetAll();
}
