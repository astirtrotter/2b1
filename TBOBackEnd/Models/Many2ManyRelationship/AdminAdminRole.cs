using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models
{
  public class AdminAdminRole
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required]
    public string AdminId { get; set; }
    public Admin Admin { get; set; }

    [Required]
    public string AdminRoleId { get; set; }
    public AdminRole AdminRole { get; set; }
  }
}
