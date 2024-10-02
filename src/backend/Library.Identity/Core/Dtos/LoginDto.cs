using System.ComponentModel.DataAnnotations;

namespace Library.Identity.Core.Dtos;

public class LoginDto 
{
    [MaxLength(20)]
    public required string Username { get; set; }

    [MaxLength(256)]
    public required string Password { get; set; }
}
