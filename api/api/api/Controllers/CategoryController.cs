using api.Commands.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : BaseApiController
{
	private readonly IMediator _mediator;

	public CategoryController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost("CreateCategory", Name = "CreateCategory")]
	public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
	{
		var result = await _mediator.Send(command);
		return CreatedAtAction(nameof(CreateCategory), result);
	}

	[HttpGet("GetCategory", Name = "GetCategory")]
	public async Task<IActionResult> GetCategory()
	{
		var result = await _mediator.Send(new GetCategoryQuery());
		return Ok(result);
	}
}
