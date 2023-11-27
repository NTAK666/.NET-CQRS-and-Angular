namespace api.Repositories.Interfaces;

public interface IUnitOfWork
{
	ICategoryRepository CategoryRepository { get; }
	IProductRepository ProductRepository { get; }

	void SaveChanges();
}
