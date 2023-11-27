using api.Dtos.Response;
using MediatR;

namespace api.Executors.Queries.Product;

public record GetProductQuery : IRequest<List<ProductResponse>>;
