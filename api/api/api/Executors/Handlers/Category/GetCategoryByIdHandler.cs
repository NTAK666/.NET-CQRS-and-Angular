using api.Commands;
using api.Dtos.Response;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.Handlers;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
	{
		var category = _unitOfWork.CategoryRepository.Find(
			predicate: x => x.Id == request.Id,
			include: x => x.Include(x => x.Products)
		);
		if (category == null)
			throw new Exception("Category not found");
		return Task.FromResult(_mapper.Map<CategoryResponse>(category));
	}
}
