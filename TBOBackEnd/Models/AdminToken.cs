using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models
{
  public class AdminToken
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required]
    public string AdminId { get; set; }
    public Admin Admin { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime LastAccessedAt { get; set; } = DateTime.Now;
  }
}
