using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Base;

namespace api.Models;

public partial class Product : BaseEntity
{
	public string Name { get; set; }
	public double Price { get; set; }
	public string Description { get; set; }
	public string Content { get; set; }
}

public partial class Product
{
	public long? CategoryId { get; set; }
	[ForeignKey("CategoryId")] public virtual Category? Category { get; set; }
}
