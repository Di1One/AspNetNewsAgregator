using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace AspNetNewsAgregatorMvcApp.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    [Remote("CheckEmail", "Account", 
        HttpMethod = WebRequestMethods.Http.Post, ErrorMessage = "Email is already exists")]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    [MinLength(8)]
    [Compare(nameof(Password))]
    public string PasswordConfirmatoin { get; set; }
}