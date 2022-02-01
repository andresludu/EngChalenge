using AutoMapper;
using Eng.Api.Models;
using Eng.Service.Contracts;
using Eng.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Eng.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ApiBaseController<UserDto, UserVm, Guid>
  {
    private readonly IUserService _userSvc;
    private readonly IMapper _mapper;
    public UserController(IService<UserDto, Guid> service, IMapper mapper,IUserService userSvc)
     : base(service, mapper)
    {
      _userSvc = userSvc;
      _mapper = mapper;
    }

    [HttpPost("UpdateStatus")]
    public async Task<IActionResult> UpdateStatus(Guid userId, bool isActive)
    {
      try
      {
        var res = await _userSvc.UpdateStatus(userId, isActive);
        return Ok(_mapper.Map<UserVm>(res));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }
  }
}
