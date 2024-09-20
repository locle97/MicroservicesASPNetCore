using Microsoft.AspNetCore.Identity;

namespace KeyboardLibrary.Identity.Domains.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
