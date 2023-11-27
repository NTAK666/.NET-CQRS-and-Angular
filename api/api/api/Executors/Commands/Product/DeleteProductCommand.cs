using api.Dtos.Response;
using MediatR;

namespace api.Executors.Commands;

public class DeleteProductCommand : IRequest<ProductResponse>
{
	public long Id { get; set; }
}
