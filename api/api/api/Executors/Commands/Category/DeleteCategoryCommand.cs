using api.Dtos.Response;
using MediatR;

namespace api.Commands;

public record DeleteCategoryCommand : IRequest<CategoryResponse>
{
	public long Id { get; set; }
}
