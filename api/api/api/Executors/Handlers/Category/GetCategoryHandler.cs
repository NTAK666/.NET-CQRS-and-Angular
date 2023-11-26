using api.Commands;
using api.Dtos.Response;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace api.Handlers;

public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, List<CategoryResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public Task<List<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
	{
		var categories = _unitOfWork.CategoryRepository.GetAll();
		return Task.FromResult(_mapper.Map<List<CategoryResponse>>(categories));
	}
}
