using api.Commands;
using api.Dtos.Response;
using api.Models;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace api.Handlers;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = new Category
		{
			Name = request.Name,
			Description = request.Description
		};
		await _unitOfWork.CategoryRepository.AddAsync(category);
		_unitOfWork.SaveChanges();
		return _mapper.Map<CategoryResponse>(category);
	}
}
