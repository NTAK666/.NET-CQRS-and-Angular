using api.Dtos.Response.Base;
using api.Models.Base;
using AutoMapper;

namespace api.Profiles;

public class BaseProfile : Profile
{
	public BaseProfile()
	{
		CreateMap<BaseEntity, BaseResponse>();
	}
}
