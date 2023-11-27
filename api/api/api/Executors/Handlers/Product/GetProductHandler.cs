using api.Dtos.Response;
using api.Executors.Queries.Product;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.Executors.Handlers.Product;

public class GetProductHandler : IRequestHandler<GetProductQuery, List<ProductResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<List<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
	{
		var products = _unitOfWork.ProductRepository.FindAll(
			include: p => p.Include(p => p.Category)
		);
		return _mapper.Map<List<ProductResponse>>(products);
	}
}
