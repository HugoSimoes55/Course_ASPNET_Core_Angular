using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")] // localhost:5001/api/members
[ApiController]
public class MembersController(AppDbContext context) : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
	{
		List<AppUser> members = await context.Users.ToListAsync();

		return members;
	}

	[HttpGet("{id}")] // localhost:5001/api/members/non-id
	public async Task<ActionResult<AppUser>> GetMember(string id)
	{
		AppUser? member = await context.Users.FindAsync(id);

		if (member == null) return NotFound();

		return member;
	}
}