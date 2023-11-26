using api.Dtos.Response.Base;

namespace api.Dtos.Response;

public class CategoryResponse : BaseResponse
{
	public long Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}
