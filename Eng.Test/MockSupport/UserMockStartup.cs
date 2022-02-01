using Eng.Data;
using Eng.Service.Contracts;
using Eng.Shared.Code;
using Eng.Shared.Dto;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSupport
{
  public static class UserMockStartup
  {

    public static readonly FilterInfo filterInfoActive = new FilterInfo { Spec = "Active", Value = string.Empty };

    public static IEnumerable<UserDto> usersDtoList;

    public static Mock<IService<UserDto, Guid>> baseUserServiceMock = new Mock<IService<UserDto, Guid>>();
    public static Mock<IUserService> userServiceMock = new Mock<IUserService>();
    public static Mock<EngContext> mock = new Mock<EngContext>();

    public static Mock<IData<UserDto, Guid>> baseUserDataMock = new Mock<IData<UserDto, Guid>>();

    public static void SetControllerMocks()
    {
      GenerateUserDtoMock();

      var first = usersDtoList.First();
      var newObj = new UserDto
      {
        Id = first.Id,
        Active = !first.Active,
        BirthDate = first.BirthDate,
        Name = first.Name,
      };

      //Controller

      baseUserServiceMock.Setup(p => p.Get()).Returns(Task.FromResult(usersDtoList));
      baseUserServiceMock.Setup(p => p.Get(It.IsAny<Guid>())).Returns(Task.FromResult(usersDtoList.First()));
      baseUserServiceMock.Setup(p => p.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(usersDtoList.First().Id));
      baseUserServiceMock.Setup(p => p.Insert(It.IsAny<UserDto>())).Returns(Task.FromResult(usersDtoList.First()));
      baseUserServiceMock.Setup(p => p.Query(filterInfoActive)).Returns(Task.FromResult(usersDtoList.Where(x => x.Active)));

      userServiceMock.Setup(p => p.UpdateStatus(It.IsAny<Guid>(), !first.Active)).Returns(Task.FromResult(newObj));
    }

    public static void SetServiceMocks()
    {
      GenerateUserDtoMock();

      var first = usersDtoList.First();
      var newObj = new UserDto
      {
        Id = first.Id,
        Active = !first.Active,
        BirthDate = first.BirthDate,
        Name = first.Name,
      };

      //Service

      baseUserDataMock.Setup(p => p.Get()).Returns(Task.FromResult(usersDtoList));
      baseUserDataMock.Setup(p => p.Get(It.IsAny<Guid>())).Returns(Task.FromResult(usersDtoList.First()));
      baseUserDataMock.Setup(p => p.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(usersDtoList.First().Id));
      baseUserDataMock.Setup(p => p.Insert(It.IsAny<UserDto>())).Returns(Task.FromResult(usersDtoList.First()));
      baseUserDataMock.Setup(p => p.Query(filterInfoActive)).Returns(Task.FromResult(usersDtoList.Where(x => x.Active)));

      baseUserDataMock.Setup(p => p.Get(first.Id)).Returns(Task.FromResult(first));
      baseUserDataMock.Setup(p => p.Update(It.IsAny<UserDto>())).Returns(Task.FromResult(newObj));
    }


    public static void SetPutMock(UserDto dto)
    {
      baseUserServiceMock.Setup(p => p.Update(It.IsAny<UserDto>())).Returns(Task.FromResult(dto));
      baseUserDataMock.Setup(p => p.Update(It.IsAny<UserDto>())).Returns(Task.FromResult(dto));
    }

    private static void GenerateUserDtoMock()
    {
      var list = new List<UserDto>();
      for (var i = 0; i < 10; i++)
      {
        list.Add(new UserDto
        {
          Active = i <= 6,
          BirthDate = DateTime.Now.AddYears(RepositoryMock.rnd.Next(-30, -20)),
          Id = Guid.NewGuid(),
          Name = RepositoryMock.firstName[RepositoryMock.rnd.Next(0, 5)] + " " + RepositoryMock.lastname[RepositoryMock.rnd.Next(0, 5)]
        });
      }
      usersDtoList = list;
    }
  }
}
