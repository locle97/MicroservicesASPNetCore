using System.ComponentModel.DataAnnotations;

namespace Library.Identity.Core.Dtos;

public class UserRegisterDto : LoginDto
{
    [EmailAddress]
    public required string Email { get; set; }
}
