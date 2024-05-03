﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace back_end.DTO
{
 public class RegisterDTO
 {

      [Required(ErrorMessage = "Email can't be blank")]
      [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
      [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email is already is use")]
      public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name can't be blank")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone Number can't be blank")]
        [RegularExpression("^[0-9]*$")]
        public string? MobaileNo { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
      public string Password { get; set; } = string.Empty;

      [Required(ErrorMessage = "Confirm Password can't be blank")]
      [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
      public string ConfirmPassword { get; set; } = string.Empty;

      public string[] Roles { get; set; } = new string[] { "User" };
    }
}
