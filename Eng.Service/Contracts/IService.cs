using Eng.Shared.Code;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eng.Service.Contracts
{
  public interface IService<TDto, TType>
    where TDto : class
    where TType : struct
  {
    Task<IEnumerable<TDto>> Get();
    Task<TDto> Get(TType id);
    Task<TDto> Insert(TDto dto);
    Task<TDto> Update(TDto dto);
    Task<TType> Delete(TType id);
    Task<IEnumerable<TDto>> Query(FilterInfo fi);
  }
}
