using System;
using System.ComponentModel.DataAnnotations;

namespace AutostoreProject.Model;

public class UserLogin
{
    [Required]
    public required string UserNameOrEmail { get; set; }
    [Required] 
    public required string Password { get; set; }

}
