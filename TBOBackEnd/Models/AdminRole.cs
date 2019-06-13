using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models
{
  public class AdminRole
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} length must be between {2} and {1}.")]
    public string Name { get; set; }

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    public ICollection<Admin> Admins { get; set; }
    public ICollection<AdminRolePermission> AdminRolePermissions { get; set; }
  }
}
