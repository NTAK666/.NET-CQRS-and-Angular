using api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("category")]
public class CategoryController : BaseApiController
{
	private readonly IMediator _mediator;

	public CategoryController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("gets")]
	public async Task<IActionResult> GetCategories()
	{
		var result = await _mediator.Send(new GetCategoryQuery());
		return Ok(result);
	}

	[HttpGet("get/{Id}")]
	public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdQuery query)
	{
		var result = await _mediator.Send(query);
		return Ok(result);
	}


	[HttpPost("create")]
	public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
	{
		var result = await _mediator.Send(command);
		return Ok(result);
	}

	[HttpDelete("delete/{Id}")]
	public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommand command)
	{
		var result = await _mediator.Send(command);
		return Ok(result);
	}

	[HttpPut("update/{Id}")]
	public async Task<IActionResult> UpdateCategory([FromRoute(Name = "Id")] long id,
		[FromBody] UpdateCategoryCommand command)
	{
		var result = await _mediator.Send(command with { Id = id });
		return Ok(result);
	}
}
