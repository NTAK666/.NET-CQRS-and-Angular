using api.Dtos.Response;
using api.Repositories.Interfaces;
using MediatR;

namespace api.Commands.Category;

public class CreateCategoryCommand : IRequest<CategoryResponse>
{
	public string Name { get; set; }
	public string Description { get; set; }
}
