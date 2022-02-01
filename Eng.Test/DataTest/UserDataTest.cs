using Eng.Shared.Code;
using Eng.Shared.Dto;
using MockSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DataTest
{
  public class UserDataTest
  {
    [Fact]
    public async Task GetAllTest()
    {
      var result = await RepositoryMock.userData.Result.Get();

      //Assert structure
      Assert.NotNull(result);
      Assert.IsType<List<UserDto>>(result);

      AssertUserProperties(result.First());

      //Assert mapped values 
      Assert.Contains(result, x => RepositoryMock.usersList.Any(m => x.Id == m.Id));

    }

    [Fact]
    public async void GetTest()
    {
      var dto = RepositoryMock.usersList.First();

      var result = await RepositoryMock.userData.Result.Get(dto.Id);

      //Assert structure
      Assert.NotNull(result);

      AssertUserProperties(result);

      //Assert mapped values 
      Assert.Equal(dto.Id, result.Id);
      Assert.Equal(dto.Name, result.Name);
      Assert.Equal(dto.BirthDate, result.BirthDate);
      Assert.Equal(dto.Active, result.Active);
    }

    [Fact]
    public async void InsertTest()
    {
      var mock = RepositoryMock.usersList.First();
      var dto = new UserDto
      {
        Active = mock.Active,
        BirthDate = mock.BirthDate,
        Name = mock.Name,
      };

      var result = await RepositoryMock.userData.Result.Insert(dto);

      //Assert structure
      Assert.NotNull(result);
      Assert.IsType<UserDto>(result);

      AssertUserProperties(result);

      //Assert mapped values 
      Assert.NotEqual(dto.Id, result.Id);
      Assert.Equal(dto.Name, result.Name);
      Assert.Equal(dto.BirthDate, result.BirthDate);
      Assert.Equal(dto.Active, result.Active);
    }

    [Fact]
    public async void DeleteTest()
    {
      var mock = RepositoryMock.usersList.First();

      var result = await RepositoryMock.userData.Result.Delete(mock.Id);

      //Assert structure
      Assert.IsType<Guid>(result);

      //Assert mapped values 
      Assert.Equal(result, mock.Id);

    }

    [Fact]
    public async void QueryTest_Active()
    {
      var result = await RepositoryMock.userData.Result.Query(UserMockStartup.filterInfoActive);

      //Assert structure
      Assert.NotNull(result);
      Assert.IsType<List<UserDto>>(result);

      AssertUserProperties(result.First());

      //Assert mapped values 
      Assert.True(result.All(x => x.Active));
    }

    [Fact]
    public async void QueryTest_NotConfiguredFilter()
    {
      var result = await RepositoryMock.userData.Result.Query(new FilterInfo { Spec = "NoFilter" });

      //Assert structure
      Assert.NotNull(result);
      Assert.IsType<List<UserDto>>(result);

      //Assert mapped values 
      Assert.True(!result.Any());
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
