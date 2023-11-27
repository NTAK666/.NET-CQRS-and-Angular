using api.Dtos.Response;
using api.Executors.Commands;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace api.Executors.Handlers.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeleteProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public Task<ProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		var product = _unitOfWork.ProductRepository.FindById(request.Id);
		if (product is null)
			throw new Exception("Product not found");
		_unitOfWork.ProductRepository.SoftDelete(product);
		return Task.FromResult(_mapper.Map<ProductResponse>(product));
	}
}
