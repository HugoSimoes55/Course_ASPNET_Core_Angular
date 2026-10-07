using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class MembersController(AppDbContext context) : BaseApiController
{
	[HttpGet]
	public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
	{
		List<AppUser> members = await context.Users.ToListAsync();

		return members;
	}

	[Authorize]
	[HttpGet("{id}")] // localhost:5001/api/members/non-id
	public async Task<ActionResult<AppUser>> GetMember(string id)
	{
		AppUser? member = await context.Users.FindAsync(id);

		if (member == null)
		{
			return NotFound();
		}

		return member;
	}
}