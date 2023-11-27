using api.Dtos.Response;
using api.Executors.Queries.Product;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.Executors.Handlers.Product;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetProductByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
	{
		var product = _unitOfWork.ProductRepository.Find(
			predicate: p => p.Id == request.Id,
			include: p => p.Include(p => p.Category)
		);
		if (product is null)
			throw new Exception("Product not found");
		return Task.FromResult(_mapper.Map<ProductResponse>(product));
	}
}
