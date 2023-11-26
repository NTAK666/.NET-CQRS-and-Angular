using api.Dtos.Response;
using MediatR;

namespace api.Commands.Category;

public record GetCategoryQuery : IRequest<List<CategoryResponse>>;
