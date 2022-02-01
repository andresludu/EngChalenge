using Eng.Data.Implementations;
using Eng.Service.Contracts;
using Eng.Shared.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eng.Service
{
  public static class Startup
  {
    public static void ConfigureServices(ref IServiceCollection services, IConfiguration config)
    {
      services.AddScoped<IData<UserDto, Guid>, UserData>();
    }
  }
}
