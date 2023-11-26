namespace api.Dtos.Response.Base;

public class BaseResponse
{
	public long Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public DateTime? DeletedAt { get; set; }
}
