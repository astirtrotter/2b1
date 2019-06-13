using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models
{
  public class AdminRolePermission
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string AdminRoleId { get; set; }
    public AdminRole AdminRole { get; set; }

    [Required]
    public string AdminPermissionId { get; set; }
    public AdminPermission AdminPermission { get; set; }
  }
}
