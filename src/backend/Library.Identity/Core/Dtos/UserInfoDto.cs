namespace Library.Identity.Core.Dtos;

public class UserInfoDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public Role? Role { get; set; }
}
