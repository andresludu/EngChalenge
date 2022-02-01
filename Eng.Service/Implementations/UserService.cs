using Eng.Service.Contracts;
using Eng.Shared.Dto;
using System;
using System.Threading.Tasks;

namespace Eng.Service.Implementations
{
  public class UserService : ServiceBase<UserDto, Guid>, IUserService
  {
    private readonly IData<UserDto, Guid> _data;

    public UserService(IData<UserDto, Guid> data) : base(data)
    {
      _data = data;
    }

    public override async Task<UserDto> Insert(UserDto dto)
    {
      dto.Id = Guid.Empty;
      dto.Active = true;
      return await base.Insert(dto);
    }

    public async Task<UserDto> UpdateStatus(Guid userId, bool isActive)
    {
      var user = await _data.Get(userId);
      user.Active = isActive;
      return await _data.Update(user);
    }
  }
}
