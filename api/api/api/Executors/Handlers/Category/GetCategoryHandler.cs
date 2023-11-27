using api.Commands;
using api.Dtos.Response;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.Handlers;

public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, List<CategoryResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger<GetCategoryHandler> _logger;

	public GetCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetCategoryHandler> logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public Task<List<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
	{
		var categories = _unitOfWork.CategoryRepository.FindAll(
			include: x => x.Include(x => x.Products)
		);

		var rs = _mapper.Map<List<CategoryResponse>>(categories);

		return Task.FromResult(rs);
	}
}
