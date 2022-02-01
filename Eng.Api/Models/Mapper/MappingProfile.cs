using AutoMapper;
using Eng.Shared.Dto;

namespace Eng.Api.Models.Mapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      //From Vm to Dto
      CreateMap<UserVm, UserDto>();

      //From Dto to Vm
      CreateMap<UserDto, UserVm>();
    }
  }
}
