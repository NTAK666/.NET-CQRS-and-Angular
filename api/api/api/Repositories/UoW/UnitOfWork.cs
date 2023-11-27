using api.Database;
using api.Repositories.Interfaces;
using api.Repositories.Repositories;

namespace api.Repositories.UoW;

public class UnitOfWork : IUnitOfWork
{
	private readonly SimpleDBContext _context;
	private ICategoryRepository _categoryRepository;
	private IProductRepository _productRepository;

	public UnitOfWork(SimpleDBContext context)
	{
		_context = context;
	}

	public ICategoryRepository CategoryRepository
	{
		get { return _categoryRepository ??= new CategoryRepository(_context); }
	}

	public IProductRepository ProductRepository
	{
		get { return _productRepository ??= new ProductRepository(_context); }
	}

	public void SaveChanges()
	{
		_context.SaveChanges();
	}
}
