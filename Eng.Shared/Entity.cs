using System.ComponentModel.DataAnnotations;

namespace Eng.Shared
{
  public class Entity<T>
  {
    public T Id { get; set; }
  }
}
