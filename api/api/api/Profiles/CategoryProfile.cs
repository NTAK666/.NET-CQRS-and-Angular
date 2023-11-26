using api.Dtos.Response;
using api.Models;
using AutoMapper;

namespace api.Profiles;

public class CategoryProfile : Profile
{
	public CategoryProfile()
	{
		CreateMap<Category, CategoryResponse>();
	}
}
