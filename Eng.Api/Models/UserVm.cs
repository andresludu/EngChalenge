using Eng.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eng.Api.Models
{
  public class UserVm : Entity<Guid>
  {
    [StringLength(200)]
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
  }
}
