using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models
{
  public class User
  {
    [Required]
    public string Id { get; set; }

    [Required, StringLength(20)]
    public string FirstName { get; set; }

    [Required, StringLength(20)]
    public string LastName { get; set; }

    public string FullName { get => $"{FirstName} {LastName}"; }
  }
}
