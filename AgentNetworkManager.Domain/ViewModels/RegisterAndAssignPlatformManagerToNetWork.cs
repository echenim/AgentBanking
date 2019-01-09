using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AgentNetworkManager.Domain.ViewModels
{
    public class RegisterAndAssignPlatformManagerToNetWork
    {
        public RegisterAndAssignPlatformManagerToNetWork()
        {
            AvailableFunction = new List<SelectListItem>();
            AvailableNetwork = new List<SelectListItem>();
           AvailableSex = new List<SelectListItem>();
    }
        [Required(ErrorMessage = "firstname is required please")]
        [Display(Name = "FirstName", Prompt = "Enter First Name ")]
        [StringLength(20, ErrorMessage = "firstname  must not be longer than 20 characters")]
        public string FirstName { get; set; }


        [Display(Name = "OtherName", Prompt = "Enter Other Name ")]
        [StringLength(20, ErrorMessage = "othername  must not be longer than 20 characters")]
        public string MidleName { get; set; }

        [Required(ErrorMessage = "lastname is required please")]
        [Display(Name = "LastName", Prompt = "Enter last Name ")]
        [StringLength(20, ErrorMessage = "last  must not be longer than 20 characters")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "gender is required please")]
        [Display(Name = "Gender", Prompt = "Enter Gender")]
        [StringLength(6, ErrorMessage = "gender  must not be longer than 20 characters")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "contact address is required please")]
        [Display(Name = "Address", Prompt = "Enter User Name ")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "contact address  must not be longer than 25 characters")]
        public string ContactAddress { get; set; }

       

        [EmailAddress]
        [Display(Name = "Email", Prompt = "email ")]
        [Required(ErrorMessage = "email is required please")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "PhoneNo", Prompt = "phone number ")]
        [Required(ErrorMessage = "phone number is required please")]
        public string Phone { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Function", Prompt = "user function")]
        public string FunctionName { get; set; }
        public string PlatformAndNetworkName { get; set; }
        public List<SelectListItem> AvailableFunction { get; set; }
        public List<SelectListItem> AvailableNetwork { get; set; }
        public List<SelectListItem> AvailableSex { get; set; }
    }
}
