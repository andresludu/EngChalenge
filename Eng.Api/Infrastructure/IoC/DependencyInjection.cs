using Eng.Service.Contracts;
using Eng.Service.Implementations;
using Eng.Shared.Dto;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eng.Api.Infrastructure.IoC
{
  public static class DependencyInjection
  {
    public static void ConfigureServices(ref IServiceCollection services)
    {
      services.AddScoped<IService<UserDto, Guid>, UserService>();
      services.AddScoped<IUserService, UserService>();
    }
  }
}
