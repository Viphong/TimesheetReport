using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimesheetReport.Core.Features.TRUsers;

namespace TimesheetReport.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }
    }

    public class ProfileViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Genders Gender { get; set; }

        public int SelectedGender { get; set; }

        public string EnglishName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [MaxLength(9),MinLength(9)]
        public string IdNumber { get; set; }

        public Guid AvatarId { get; set; }
    }

    public class EditProfileViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Genders Gender { get; set; }

        [Display(Name = "Gender")]
        public int SelectedGender { get; set; }

        public string EnglishName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [MaxLength(9), MinLength(9)]
        public string IdNumber { get; set; }

        public Guid AvatarId { get; set; }

    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}