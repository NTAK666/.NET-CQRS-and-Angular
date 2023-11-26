using api.Dtos.Response;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Commands;

public record UpdateCategoryCommand : IRequest<CategoryResponse>
{
	[SwaggerSchema(ReadOnly = true)] public long Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
}
