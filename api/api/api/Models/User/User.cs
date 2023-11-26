using api.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace api.Models.User;

public class User : IdentityUser, IBaseEntity
{
	public new long Id { get; set; }

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string? Address { get; set; }

	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public DateTime? DeletedAt { get; set; }
}
