using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Models
{
    public class CreateUserBindingModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public List<string> Roles { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name="Latitude")]
        public string Latitude { get; set; }
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Display(Name = "Client")]
        public int Client { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Display(Name="Id Local")]
        public int IdLocal { get; set; }
    }


    public class EditUserBindingModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Display(Name = "Client")]
        public int Client { get; set; }
        [Display(Name = "Logo")]
        public string Logo { get; set; }
        [Display(Name = "Id Local")]
        public int IdLocal { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public List<string> Roles { get; set; }

      
    }

    public class ChangePasswordBindingModel
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

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    
    }
}