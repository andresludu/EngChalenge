using AutoMapper;
using Eng.Api.Controllers;
using Eng.Api.Models;
using Eng.Api.Models.Mapper;
using Eng.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiTest
{
  public class UserControllerTest
  {
    private static IMapper _mapper;
    UserController userController;

    public UserControllerTest()
    {
      if (_mapper == null)
      {
        var mappingConfig = new MapperConfiguration(mc =>
        {
          mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        _mapper = mapper;
      }

      UserMockStartup.SetControllerMocks();
      userController = new UserController(UserMockStartup.baseUserServiceMock.Object, _mapper, UserMockStartup.userServiceMock.Object);
    }

    [Fact]
    public void GetAllTest()
    {
      var result = userController.Get();

      var response = result.Result as OkObjectResult;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.Equal(response.StatusCode, StatusCodes.Status200OK);
      Assert.IsType<List<UserVm>>(response.Value);

      var list = response.Value as List<UserVm>;

      AssertUserProperties(list.First());

      //Assert mapped values 
      Assert.Contains(list, x => UserMockStartup.usersDtoList.Any(m => x.Id == m.Id));
    }

    [Fact]
    public void GetTest()
    {
      var dto = UserMockStartup.usersDtoList.First();
      var result = userController.Get(dto.Id);

      var response = result.Result as OkObjectResult;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.Equal(response.StatusCode, StatusCodes.Status200OK);
      Assert.IsType<UserVm>(response.Value);

      var vm = response.Value as UserVm;

      AssertUserProperties(vm);

      //Assert mapped values 
      Assert.Equal(dto.Id, vm.Id);
      Assert.Equal(dto.Name, vm.Name);
      Assert.Equal(dto.BirthDate, vm.BirthDate);
      Assert.Equal(dto.Active, vm.Active);
    }

    [Fact]
    public void PostTest()
    {
      var mock = UserMockStartup.usersDtoList.First();
      var dto = new UserVm
      {
        BirthDate = mock.BirthDate,
        Name = mock.Name,
      };

      var result = userController.Post(_mapper.Map<UserVm>(dto));

      var response = result.Result as OkObjectResult;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.Equal(response.StatusCode, StatusCodes.Status200OK);
      Assert.IsType<UserVm>(response.Value);

      var vm = response.Value as UserVm;

      AssertUserProperties(vm);

      //Assert mapped values 
      Assert.NotEqual(dto.Id, vm.Id);
      Assert.Equal(dto.Name, vm.Name);
      Assert.Equal(dto.BirthDate, vm.BirthDate);
      Assert.True(vm.Active);
    }

    [Fact]
    public void PutTest()
    {
      var mock = UserMockStartup.usersDtoList.First();
      var requestVm = new UserVm
      {
        Id = mock.Id,
        BirthDate = mock.BirthDate.AddDays(-45),
        Name = "Nuevo nombre",
      };

      UserMockStartup.SetPutMock(new UserDto
      {
        Id = requestVm.Id,
        Active = requestVm.Active,
        BirthDate = requestVm.BirthDate,
        Name = requestVm.Name,
      });

      var result = userController.Put(_mapper.Map<UserVm>(requestVm));

      var response = result.Result as OkObjectResult;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.Equal(response.StatusCode, StatusCodes.Status200OK);
      Assert.IsType<UserVm>(response.Value);

      var responseVm = response.Value as UserVm;

      AssertUserProperties(responseVm);

      //Assert mapped values 
      Assert.Equal(requestVm.Id, responseVm.Id);
      Assert.Equal(requestVm.Name, responseVm.Name);
      Assert.Equal(requestVm.BirthDate, responseVm.BirthDate);
      Assert.Equal(requestVm.Active, responseVm.Active);
    }

    [Fact]
    public void DeleteTest()
    {
      var mock = UserMockStartup.usersDtoList.First();

      var result = userController.Delete(mock.Id);

      var response = result.Result as OkObjectResult;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.Equal(response.StatusCode, StatusCodes.Status200OK);
      Assert.IsType<Guid>(response.Value);

      //Assert mapped values 
      Assert.Equal(response.Value, mock.Id);
    }

    [Fact]
    public void QueryTest()
    {
      var result = userController.Query(UserMockStartup.filterInfoActive);

      var response = result.Result as OkObjectResult;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.Equal(response.StatusCode, StatusCodes.Status200OK);
      Assert.IsType<List<UserVm>>(response.Value);

      var list = response.Value as List<UserVm>;

      AssertUserProperties(list.First());

      //Assert mapped values 
      Assert.True(list.All(x => x.Active));
    }

    [Fact]
    public void UpdateStatusTest()
    {
      var dto = UserMockStartup.usersDtoList.First();
      var result = userController.UpdateStatus(dto.Id, !dto.Active);

      var response = result.Result as OkObjectResult;

      //Assert structure
      Assert.NotNull(result);
      Assert.NotNull(response);
      Assert.Equal(response.StatusCode, StatusCodes.Status200OK);
      Assert.IsType<UserVm>(response.Value);

      var vm = response.Value as UserVm;

      AssertUserProperties(vm);

      //Assert mapped values 
      Assert.Equal(dto.Id, vm.Id);
      Assert.Equal(dto.Name, vm.Name);
      Assert.Equal(dto.BirthDate, vm.BirthDate);
      Assert.Equal(!dto.Active, vm.Active);
    }

    private void AssertUserProperties(UserVm obj)
    {
      Assert.IsType<Guid>(obj.Id);
      Assert.IsType<string>(obj.Name);
      Assert.IsType<DateTime>(obj.BirthDate);
      Assert.IsType<bool>(obj.Active);

      Assert.True(obj.GetType().GetProperties().Length == 4);
    }
  }
}
