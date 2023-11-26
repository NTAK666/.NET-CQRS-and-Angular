using api.Dtos.Response;
using MediatR;

namespace api.Commands;

public record GetCategoryQuery : IRequest<List<CategoryResponse>>;
