using api.Database;
using api.Repositories.Interfaces;
using api.Repositories.Repositories;

namespace api.Repositories.UoW;

public class UnitOfWork : IUnitOfWork
{
	private readonly SimpleDBContext _context;
	private ICategoryRepository _categoryRepository;

	public UnitOfWork(SimpleDBContext context)
	{
		_context = context;
	}

	public ICategoryRepository CategoryRepository
	{
		get { return _categoryRepository ??= new CategoryRepository(_context); }
	}

	public void SaveChanges()
	{
		_context.SaveChanges();
	}
}
