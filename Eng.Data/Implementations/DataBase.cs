using AutoMapper;
using Eng.Data;
using Eng.Service.Contracts;
using Eng.Shared;
using Eng.Shared.Code;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eng.Service.Implementations
{
  public abstract class DataBase<TEntity, TDto, TType> : IData<TDto, TType>
    where TEntity : class
    where TDto : class
    where TType : struct
  {
    internal readonly DbSet<TEntity> entity;
    internal readonly EngContext context;
    private readonly IMapper _mapper;

    public DataBase(EngContext context, DbSet<TEntity> entity, IMapper mapper)
    {
      this.context = context;
      this.entity = entity;
      _mapper = mapper;
    }

    public virtual async Task<TDto> Get(TType id)
    {
      var entity = await this.entity.FindAsync(id);
      if (entity != null)
      {
        this.context.Entry(entity).State = EntityState.Detached;
      }

      return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<IEnumerable<TDto>> Get()
    {
      var list = await this.entity.ToListAsync();
      return _mapper.Map<List<TDto>>(list);
    }

    public virtual async Task<TDto> Insert(TDto dto)
    {
      var entity = _mapper.Map<TEntity>(dto);

      this.entity.Add(entity);
      await this.context.SaveChangesAsync();

      this.Reload(ref entity);
      return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> Update(TDto dto)
    {
      var entity = _mapper.Map<TEntity>(dto);

      if (entity != null)
      {
        this.entity.Update(entity);
        await this.context.SaveChangesAsync();

        this.Reload(ref entity);
      }

      return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TType> Delete(TType id)
    {
      var dto = await this.Get(id);
      var entity = _mapper.Map<TEntity>(dto);
      this.context.Remove(entity);
      await this.context.SaveChangesAsync();
      return id;
    }

    public virtual async Task<IEnumerable<TDto>> Query(FilterInfo fi)
    {
      throw new NotImplementedException();
    }

    private TEntity Reload(ref TEntity value)
    {
      if (value == null)
      {
        return null;
      }

      var e = value as Entity<TType>;

      this.context.Entry(value).State = EntityState.Detached;
      TEntity outValue = this.entity.Find(e.Id);
      value = outValue;
      return outValue;
    }
  }
}
