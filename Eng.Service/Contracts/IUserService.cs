using Eng.Shared.Dto;
using System;
using System.Threading.Tasks;

namespace Eng.Service.Contracts
{
  public interface IUserService 
  {
    Task<UserDto> UpdateStatus(Guid userId, bool isActive);
  }
}
