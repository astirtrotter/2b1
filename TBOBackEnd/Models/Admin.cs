﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Models.Many2ManyRelationship;

namespace TBOBackEnd.Models
{
  public class Admin
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} length must be between {2} and {1}.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} length must be between {2} and {1}.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [Remote(action: "VerifyEmail", controller: "Admins")]
    public string Email { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

    [Required]
    public AccountStatus AdminAccountStatusId { get; set; }
    public AdminAccountStatus AdminAccountStatus { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}")]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true, NullDisplayText = "(no access)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? LastAccessedAt { get; set; } = DateTime.Now;

    /*****************************************************************************************************/

    public virtual string FullName { get => $"{FirstName} {LastName}"; }

    public ICollection<AdminAdminRole> AdminAdminRoles { get; set; }
    public ICollection<AdminToken> AdminTokens { get; set; }

    /*****************************************************************************************************/

    public bool HasPermission(Permission permission) =>
      AdminAdminRoles.Any(adminAdminRole =>
        adminAdminRole.AdminRole.HasPermission(permission));
  }
}
