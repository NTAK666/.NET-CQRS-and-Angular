using api.Dtos.Response;
using api.Models;
using AutoMapper;

namespace api.Profiles;

public class ProductProfile : Profile
{
	public ProductProfile()
	{
		CreateMap<Product, ProductResponse>()
			.MaxDepth(2);
	}
}
