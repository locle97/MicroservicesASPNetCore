using System.ComponentModel.DataAnnotations;

namespace Library.Identity.Core;

public class User : BaseEntity
{
    [MaxLength(20)]
    public required string Username { get; set; }

    [MaxLength(256)]
    public required string Password { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public int? RoleId { get; set; }

    public Role? Role { get; set; }
}
