using Eng.Service.Contracts;
using Eng.Shared.Code;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eng.Service.Implementations
{
  public abstract class ServiceBase<TDto, TType> : IService<TDto, TType>
    where TDto : class
    where TType : struct
  {

    private readonly IData<TDto, TType> _data;

    public ServiceBase(IData<TDto, TType> data)
    {
      this._data = data;
    }

    public virtual async Task<IEnumerable<TDto>> Get()
    {
      return await _data.Get();
    }

    public virtual async Task<TDto> Get(TType id)
    {
      return await _data.Get(id);
    }

    public virtual async Task<TDto> Insert(TDto dto)
    {
      return await _data.Insert(dto);
    }

    public virtual async Task<TDto> Update(TDto dto)
    {
      return await _data.Update(dto);
    }

    public virtual async Task<TType> Delete(TType userId)
    {
      return await _data.Delete(userId);
    }

    public virtual async Task<IEnumerable<TDto>> Query(FilterInfo fi)
    {
      return await _data.Query(fi);
    }
  }
}
