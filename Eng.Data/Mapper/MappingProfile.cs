using AutoMapper;
using Eng.Domain.Entity;
using Eng.Shared.Dto;

namespace Eng.AplicationData.Mappers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      //From Dto to Entity
      CreateMap<UserDto, User>();

      //From Entity to Dto
      CreateMap<User, UserDto>();
    }
  }
}
