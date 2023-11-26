using api.Commands.Category;
using api.Dtos.Response;
using api.Repositories.Interfaces;
using MediatR;

namespace api.Handlers.Category;

public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, List<CategoryResponse>>
{
	private readonly ICategoryRepository _categoryRepository;

	public GetCategoryHandler(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public Task<List<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
	{
		var categories = _categoryRepository.GetAll();
		var categoryResponses = categories.Select(category => new CategoryResponse
		{
			Name = category.Name,
			Description = category.Description
		}).ToList();

		return Task.FromResult(categoryResponses);
	}
}
