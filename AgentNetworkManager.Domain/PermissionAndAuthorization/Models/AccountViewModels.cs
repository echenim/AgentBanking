﻿using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.PermissionAndAuthorization.Models
{
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
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Function", Prompt = "user function")]
        public string Function { get; set; }


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
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
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