using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static MacroMinder.Data.ApplicationUser;

namespace MacroMinder.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Text)]
        [Range(1,int.MaxValue,ErrorMessage = "Please select your gender.")]
        [Display(Name = "Gender")]
        public Sex Gender { get; set; }
        public List<SelectListItem> Genders { get; set; }
        public RegisterViewModel()
        {
            Genders = new List<SelectListItem>();
            Genders.Add(new SelectListItem
            {
                Value = Sex.male.ToString(),
                Text = Sex.male.ToString()
            });
            Genders.Add(new SelectListItem
            {
                Value = Sex.female.ToString(),
                Text = Sex.female.ToString()
            });

            Goals = new List<SelectListItem>();
            Goals.Add(new SelectListItem
            {
                Value = Goal.lose.ToString(),
                Text = Goal.lose.ToString()
            });
            Goals.Add(new SelectListItem
            {
                Value = Goal.gain.ToString(),
                Text = Goal.gain.ToString()
            });
            Goals.Add(new SelectListItem
            {
                Value = Goal.maintain.ToString(),
                Text = Goal.maintain.ToString()
            });
        }

        [DataType(DataType.Text)]
        [Display(Name = "Weight in Pounds")]
        public string Weight { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Height in Inches")]
        public string Height { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "BMR")]
        public string BMR { get; set; }

        [DataType(DataType.Text)]
        [Range(1,int.MaxValue,ErrorMessage = "Please select your dietary goal.")]
        [Display(Name = "Dietary Goal - lose, gain, or maintain")]
        public Goal DietaryGoal { get; set; }
        public List<SelectListItem> Goals { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
