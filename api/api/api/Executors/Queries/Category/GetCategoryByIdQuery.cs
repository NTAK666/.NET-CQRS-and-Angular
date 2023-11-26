using api.Dtos.Response;
using MediatR;

namespace api.Commands;

public record GetCategoryByIdQuery : IRequest<CategoryResponse>
{
	public long Id { get; set; }
}
