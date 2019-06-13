using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models
{
  public class AdminAccountStatus
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public AccountStatus AccountStatus { get; set; }

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    /*****************************************************************************************************/

    public virtual string Name { get => AccountStatus.ToName(); }

    public ICollection<Admin> Admins { get; set; }
  }


  public enum AccountStatus
  {
    [Description("Pending")]
    Pending = 1,
    [Description("Active")]
    Active = 2,
    [Description("Suspended")]
    Suspended = 3,
    [Description("Deleted")]
    Deleted = 4,
  }


  public static class AccountStatusExtension
  {
    public static string ToName(this AccountStatus accountStatus)
    {
      DescriptionAttribute[] attributes = (DescriptionAttribute[])accountStatus
        .GetType()
        .GetField(accountStatus.ToString())
        .GetCustomAttributes(typeof(DescriptionAttribute), false);
      return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
  }
}
