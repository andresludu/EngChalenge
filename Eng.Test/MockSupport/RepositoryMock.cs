using AutoMapper;
using Eng.Data;
using Eng.Data.Implementations;
using Eng.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;
using MockSupport;
using System.Threading.Tasks;

namespace MockSupport
{
  public static class RepositoryMock
  {
    public static readonly Random rnd = new Random((int)DateTime.Now.Ticks);
    public static readonly string[] firstName = { "juan", "pablo", "Paco", "jose", "Alberto", };
    public static readonly string[] lastname = { "sanchez", "perez", "lopez", "zelaya", "alvarez", };

    public static List<User> usersList;

    private static DbContextOptions<EngContext> dbContextOptions;
    private static IMapper _mapper;
    private static readonly IConfiguration _configuration;
    public static Task<UserData> userData = CreateUserRepositoryAsync();

    private static async Task<UserData> CreateUserRepositoryAsync()
    {
      var dbName = $"AuthorPostsDb_{DateTime.Now.ToFileTimeUtc()}";
      dbContextOptions = new DbContextOptionsBuilder<EngContext>()
          .UseInMemoryDatabase(dbName)
          .Options;
      CheckMapper();
      GenerateUserMock();

      EngContext context = new EngContext(_configuration, dbContextOptions);
      await PopulateUserDataAsync(context);
      return new UserData(context, _mapper);
    }

    private static async Task PopulateUserDataAsync(EngContext context)
    {
      usersList.ForEach(async u =>
      {
        await context.User.AddAsync(u);
      });

      await context.SaveChangesAsync();
    }

    private static void GenerateUserMock()
    {
      var list = new List<User>();
      for (var i = 0; i < 10; i++)
      {
        list.Add(new User
        {
          Active = i <= 6,
          BirthDate = DateTime.Now.AddYears(rnd.Next(-30, -20)),
          Id = Guid.NewGuid(),
          Name = firstName[rnd.Next(0, 5)] + " " + lastname[rnd.Next(0, 5)]
        });
      }
      usersList = list;
    }

    private static void CheckMapper()
    {
      if (_mapper == null)
      {
        var mappingConfig = new MapperConfiguration(mc =>
        {
          mc.AddProfile(new Eng.AplicationData.Mappers.MappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        _mapper = mapper;
      }
    }
  }
}
