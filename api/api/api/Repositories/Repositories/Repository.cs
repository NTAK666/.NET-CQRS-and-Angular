using System.Linq.Expressions;
using api.Database;
using api.Models.Base;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace api.Repositories.Repositories;

public class Repository<T, K> : IRepository<T, K> where T : class, IBaseEntity, new() where K : struct
{
	private readonly SimpleDBContext _context;
	private readonly DbSet<T> _dbSet;

	public Repository(SimpleDBContext context)
	{
		_context = context;
		_dbSet = context.Set<T>();
	}

	public Task<T> AddAsync(T entity)
	{
		var t = _context.Add(entity);
		return Task.FromResult(t.Entity);
	}

	public Task<T> UpdateAsync(T entity)
	{
		var t = _context.Update(entity);
		return Task.FromResult(t.Entity);
	}

	public T? Find(Expression<Func<T, T>>? selector = null, Expression<Func<T, bool>>? predicate = null,
		Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
		Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true,
		bool ignoreQueryFilters = false)
	{
		IQueryable<T> query = _dbSet;
		if (ignoreQueryFilters)
			query = query.IgnoreQueryFilters();

		if (include != null)
			query = include(query);

		if (predicate != null)
			query = query.Where(predicate);

		if (orderBy != null)
			query = orderBy(query).Select(selector!).AsQueryable();

		if (disableTracking)
			query = query.AsNoTracking();

		return query.FirstOrDefault();
	}

	public bool SoftDelete(T entity)
	{
		entity.DeletedAt = DateTime.Now;
		_context.Update(entity);
		return true;
	}

	public T? FindById(K id)
	{
		return _dbSet.Find(id);
	}

	public List<T> GetAll()
	{
		return _dbSet.ToList();
	}
}
