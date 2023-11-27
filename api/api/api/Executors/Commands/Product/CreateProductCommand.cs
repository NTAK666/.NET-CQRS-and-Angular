using api.Dtos.Response;
using MediatR;

namespace api.Executors.Commands.Product;

public record CreateProductCommand : IRequest<ProductResponse>
{
	public string Name { get; set; }
	public double Price { get; set; }
	public string Description { get; set; }
	public string Content { get; set; }
	public long CategoryId { get; set; }
}
