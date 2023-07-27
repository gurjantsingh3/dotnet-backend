using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Tempo_Backend.Models.User;
public class User
{
    public int? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

}


public class UserDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required, EmailAddress]

    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
