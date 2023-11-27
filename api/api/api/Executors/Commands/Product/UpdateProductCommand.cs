using api.Dtos.Response;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Executors.Commands.Product;

public record UpdateProductCommand : IRequest<ProductResponse>
{
	[SwaggerSchema(ReadOnly = true)] public long Id { get; set; }
	public string? Name { get; set; }
	public double? Price { get; set; }
	public string? Description { get; set; }
	public string? Content { get; set; }
	public long? CategoryId { get; set; }
}
