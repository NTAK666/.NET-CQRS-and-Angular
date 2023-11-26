namespace api.Repositories.Interfaces;

public interface IUnitOfWork
{
	ICategoryRepository CategoryRepository { get; }

	void SaveChanges();
}
