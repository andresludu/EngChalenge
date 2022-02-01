using System;

namespace Eng.Shared.Dto
{
  public class UserDto : Entity<Guid>
  {
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
  }
}
