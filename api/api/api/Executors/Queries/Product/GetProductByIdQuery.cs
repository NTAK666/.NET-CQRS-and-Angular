using api.Dtos.Response;
using MediatR;

namespace api.Executors.Queries.Product;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
	public long Id { get; set; }
}
