using api.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace api.Models.User;

public class Role : IdentityRole, IBaseEntity
{
	public new long Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public DateTime? DeletedAt { get; set; }
}
