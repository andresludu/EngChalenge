using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eng.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public abstract class BaseController : ControllerBase
  {
    public BaseController()
    {
    }
  }
}
