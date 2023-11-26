using api.Database;
using api.Models;
using api.Repositories.Interfaces;

namespace api.Repositories.Repositories;

public class ProductRepository : Repository<Product, long>, IProductRepository
{
	public ProductRepository(SimpleDBContext context) : base(context)
	{
	}
}
