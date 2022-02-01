using Eng.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eng.Domain.Entity
{
  public class User : Entity<Guid>
  {
    [MaxLength(200)]
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public bool Active { get; set; }
  }
}
