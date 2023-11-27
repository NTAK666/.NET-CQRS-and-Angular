using api.Dtos.Response;
using api.Executors.Commands.Product;
using api.Models;
using api.Repositories.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api.Executors.Handlers.Product;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var category = default(Category);

		var product = _unitOfWork.ProductRepository.Find(
			predicate: x => x.Id == request.Id,
			include: x => x.Include(x => x.Category)
		);
		if (product is null)
			throw new Exception("Product not found");

		if (request.CategoryId is not null)
			category = _unitOfWork.CategoryRepository.FindById(request.CategoryId.Value);

		if (category is null)
			throw new Exception("Category not found");

		product.Name = request.Name ?? product.Name;
		product.Price = request.Price ?? product.Price;
		product.Description = request.Description ?? product.Description;
		product.Content = request.Content ?? product.Content;
		product.Category = category;

		await _unitOfWork.ProductRepository.UpdateAsync(product);

		return _mapper.Map<ProductResponse>(product);
	}
}
