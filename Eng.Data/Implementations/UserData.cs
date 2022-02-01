using AutoMapper;
using Eng.Domain.Entity;
using Eng.Service.Implementations;
using Eng.Shared.Code;
using Eng.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eng.Data.Implementations
{
  public class UserData : DataBase<User, UserDto, Guid>
  {
    private readonly IMapper _mapper;
    public UserData(EngContext InduplastContext, IMapper mapper)
   : base(InduplastContext, InduplastContext.User, mapper)
    {
      _mapper = mapper;
    }

    public override async Task<IEnumerable<UserDto>> Query(FilterInfo fi)
    {
      var list = new List<User>();
      switch (fi.Spec.ToLower())
      {
        case SpecFilter.User.Active:
          {
            list = (await this.entity.ToListAsync()).FindAll(x => x.Active);
          }
          break;
        default:
          break;

      }

      return _mapper.Map<List<UserDto>>(list);
    }
  }
}
