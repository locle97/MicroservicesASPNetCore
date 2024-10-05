using System.ComponentModel.DataAnnotations;

namespace Library.Identity.Core;

public class Role : BaseEntity
{
    [MaxLength(10)]
    public required string Code { get; set; }

    [MaxLength(256)]
    public required string Name { get; set; }

    public List<User> Users { get; set; } = [];
}
