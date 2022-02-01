using AutoMapper;
using Eng.Service.Contracts;
using Eng.Shared.Code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eng.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public abstract class ApiBaseController<TDto, TVm, TType> : BaseController
    where TDto : class
    where TVm : class
    where TType : struct
  {
    private readonly IService<TDto, TType> logicBase;
    private readonly IMapper _mapper;

    public ApiBaseController(IService<TDto, TType> logicBase, IMapper mapper)
      : base()
    {
      this.logicBase = logicBase;
      _mapper = mapper;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
      try
      {
        var result = await this.logicBase.Get();
        return Ok(_mapper.Map<List<TVm>>(result));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(TType id)
    {
      try
      {
        var result = await this.logicBase.Get(id);
        return Ok(_mapper.Map<TVm>(result));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] TVm value)
    {
      try
      {
        var result = await this.logicBase.Insert(_mapper.Map<TDto>(value));
        return Ok(_mapper.Map<TVm>(result));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPut]
    public virtual async Task<IActionResult> Put([FromBody] TVm value)
    {
      try
      {
        var result = await this.logicBase.Update(_mapper.Map<TDto>(value));
        return Ok(_mapper.Map<TVm>(result));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult> Delete(TType id)
    {
      try
      {
        var result = await this.logicBase.Delete(id);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost("Query")]
    public virtual async Task<IActionResult> Query([FromBody] FilterInfo fi)
    {
      try
      {
        var result = await this.logicBase.Query(fi);
        return Ok(_mapper.Map<List<TVm>>(result));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }
  }
}
