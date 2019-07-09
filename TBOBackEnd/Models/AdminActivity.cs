using Microsoft.AspNetCore.Mvc;
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
  public class AdminActivity
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required]
    public string AdminId { get; set; }
    public Admin Admin { get; set; }

    [Required]
    public Action Action { get; set; }

    [Required]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
  }


  public enum Action
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


  public static class ActionExtension
  {
    public static string ToDescription(this Action action)
    {
      DescriptionAttribute[] attributes = (DescriptionAttribute[])action
        .GetType()
        .GetField(action.ToString())
        .GetCustomAttributes(typeof(DescriptionAttribute), false);
      return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
  }
}
