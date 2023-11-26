using api.Database;
using api.Models;
using api.Repositories.Interfaces;

namespace api.Repositories.Repositories;

public class CategoryRepository : Repository<Category, long>, ICategoryRepository
{
	public CategoryRepository(SimpleDBContext context) : base(context)
	{
	}
}
