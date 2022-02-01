using Eng.Service.Implementations;
using Eng.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using MockSupport;
using Xunit;

namespace ServiceTest
{
  public class UserServiceTest
  {
    readonly UserService userService;

    public UserServiceTest()
    {
      UserMockStartup.SetServiceMocks();
      userService = new UserService(UserMockStartup.baseUserDataMock.Object);
    }

    [Fact]
    public void GetAllTest()
    {
      var result = userService.Get();

      var response = result.Result;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.IsType<List<UserDto>>(response);

      AssertUserProperties(response.First());

      //Assert mapped values 
      Assert.Contains(response, x => UserMockStartup.usersDtoList.Any(m => x.Id == m.Id));
    }

    [Fact]
    public void GetTest()
    {
      var dto = UserMockStartup.usersDtoList.First();
      var result = userService.Get(dto.Id);

      var response = result.Result;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.IsType<UserDto>(response);

      AssertUserProperties(response);

      //Assert mapped values 
      Assert.Equal(dto.Id, response.Id);
      Assert.Equal(dto.Name, response.Name);
      Assert.Equal(dto.BirthDate, response.BirthDate);
      Assert.Equal(dto.Active, response.Active);
    }

    [Fact]
    public void PostTest()
    {
      var mock = UserMockStartup.usersDtoList.First();
      var dto = new UserDto
      {
        Active = mock.Active,
        BirthDate = mock.BirthDate,
        Name = mock.Name,
      };

      var result = userService.Insert(dto);

      var response = result.Result;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.IsType<UserDto>(response);

      AssertUserProperties(response);

      //Assert mapped values 
      Assert.NotEqual(dto.Id, response.Id);
      Assert.Equal(dto.Name, response.Name);
      Assert.Equal(dto.BirthDate, response.BirthDate);
      Assert.Equal(dto.Active, response.Active);
    }

    [Fact]
    public void PutTest()
    {
      var mock = UserMockStartup.usersDtoList.First();
      var requestDto = new UserDto
      {
        Id = mock.Id,
        Active = true,
        BirthDate = mock.BirthDate.AddDays(-45),
        Name = "Nuevo nombre",
      };

      UserMockStartup.SetPutMock(new UserDto
      {
        Id = requestDto.Id,
        Active = requestDto.Active,
        BirthDate = requestDto.BirthDate,
        Name = requestDto.Name,
      });

      var result = userService.Update(requestDto);

      var response = result.Result;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.IsType<UserDto>(response);

      AssertUserProperties(response);

      //Assert mapped values 
      Assert.Equal(requestDto.Id, response.Id);
      Assert.Equal(requestDto.Name, response.Name);
      Assert.Equal(requestDto.BirthDate, response.BirthDate);
      Assert.Equal(requestDto.Active, response.Active);
    }

    [Fact]
    public void DeleteTest()
    {
      var mock = UserMockStartup.usersDtoList.First();

      var result = userService.Delete(mock.Id);

      //Assert structure
      Assert.NotNull(result);
      Assert.IsType<Guid>(result.Result);

      //Assert mapped values 
      Assert.Equal(result.Result, mock.Id);
    }

    [Fact]
    public void QueryTest()
    {
      var result = userService.Query(UserMockStartup.filterInfoActive);

      var response = result.Result.ToList();

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.IsType<List<UserDto>>(response);

      AssertUserProperties(response.First());

      //Assert mapped values 
      Assert.True(response.All(x => x.Active));
    }

    [Fact]
    public void UpdateStatusTest()
    {
      var dto = UserMockStartup.usersDtoList.First();
      var result = userService.UpdateStatus(dto.Id, !dto.Active);

      var response = result.Result;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.IsType<UserDto>(response);

      AssertUserProperties(response);

      //Assert mapped values 
      Assert.Equal(dto.Id, response.Id);
      Assert.Equal(dto.Name, response.Name);
      Assert.Equal(dto.BirthDate, response.BirthDate);

      //Here the logic inside the method is validated, in this case it is the update of the state.
      Assert.Equal(dto.Active, response.Active);
    }

    private void AssertUserProperties(UserDto obj)
    {
      Assert.IsType<Guid>(obj.Id);
      Assert.IsType<string>(obj.Name);
      Assert.IsType<DateTime>(obj.BirthDate);
      Assert.IsType<bool>(obj.Active);

      Assert.True(obj.GetType().GetProperties().Length == 4);
    }
  }
}
