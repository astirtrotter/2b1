using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Models.Many2ManyRelationship;

namespace TBOBackEnd.Models
{
  public class AdminPermission
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Permission permission { get; set; }

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    /*****************************************************************************************************/

    public virtual string Name { get => permission.ToName(); }

    public ICollection<AdminRolePermission> AdminRolePermissions { get; set; }

  }


  public enum Permission
  {
    [Description("Add")]
    Add = 1,
    [Description("Modify")]
    Modify = 2,
    [Description("Delete")]
    Delete = 3,
    [Description("Hide")]
    Hide = 4,
    [Description("Show")]
    Show = 5
  }


  public static class PermissionExtension
  {
    public static string ToName(this Permission permission)
    {
      DescriptionAttribute[] attributes = (DescriptionAttribute[])permission
        .GetType()
        .GetField(permission.ToString())
        .GetCustomAttributes(typeof(DescriptionAttribute), false);
      return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
  }
}
