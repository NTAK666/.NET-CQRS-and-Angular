using api.Models.Base;

namespace api.Models;

public partial class Category : BaseEntity
{
	public string Name { get; set; }
	public string Description { get; set; }
}

public partial class Category
{
	public ICollection<Product> Products { get; set; } = new List<Product>();
}
