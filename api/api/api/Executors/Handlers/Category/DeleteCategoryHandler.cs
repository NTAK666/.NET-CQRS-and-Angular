using api.Commands;
using api.Dtos.Response;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace api.Handlers;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, CategoryResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeleteCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public Task<CategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = _unitOfWork.CategoryRepository.FindById(request.Id);
		if (category == null)
			throw new Exception("Category not found");
		_unitOfWork.CategoryRepository.SoftDelete(category);
		return Task.FromResult(_mapper.Map<CategoryResponse>(category));
	}
}
