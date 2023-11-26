using api.Dtos.Response;
using MediatR;

namespace api.Commands;

public record CreateCategoryCommand : IRequest<CategoryResponse>
{
	public string Name { get; set; }
	public string Description { get; set; }
}
