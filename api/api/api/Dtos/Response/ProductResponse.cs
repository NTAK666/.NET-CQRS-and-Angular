using api.Dtos.Response.Base;

namespace api.Dtos.Response;

public class ProductResponse : BaseResponse
{
	public string Name { get; set; }
	public double Price { get; set; }
	public string Description { get; set; }
	public string Content { get; set; }
	public CategoryResponse? Category { get; set; }
}
