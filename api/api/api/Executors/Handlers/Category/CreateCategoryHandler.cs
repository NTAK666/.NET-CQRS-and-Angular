using api.Commands.Category;
using api.Dtos.Response;
using api.Repositories.Interfaces;
using MediatR;

namespace api.Handlers.Category;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateCategoryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = new Models.Category
		{
			Name = request.Name,
			Description = request.Description
		};
		await _unitOfWork.CategoryRepository.AddAsync(category);
		_unitOfWork.SaveChanges();
		return new CategoryResponse()
		{
			Name = category.Name,
			Description = category.Description,
		};
	}
}
