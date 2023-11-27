using api.Dtos.Response;
using api.Executors.Commands.Product;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;

namespace api.Executors.Handlers.Product;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var category = _unitOfWork.CategoryRepository.FindById(request.CategoryId);
		if (category is null)
			throw new Exception("Category not found");

		var product = new Models.Product()
		{
			Name = request.Name,
			Price = request.Price,
			Description = request.Description,
			Content = request.Content,
			CategoryId = request.CategoryId
		};
		await _unitOfWork.ProductRepository.AddAsync(product);
		_unitOfWork.SaveChanges();
		return _mapper.Map<ProductResponse>(product);
	}
}
