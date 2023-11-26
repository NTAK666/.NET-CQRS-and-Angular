using api.Commands;
using api.Dtos.Response;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace api.Handlers;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>,
	IRequest<CategoryResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = _unitOfWork.CategoryRepository.FindById(request.Id);
		if (category == null)
			throw new Exception("Category not found");
		category.Name = request.Name ?? category.Name;
		category.Description = request.Description ?? category.Description;
		await _unitOfWork.CategoryRepository.UpdateAsync(category);
		_unitOfWork.SaveChanges();
		return _mapper.Map<CategoryResponse>(category);
	}
}
