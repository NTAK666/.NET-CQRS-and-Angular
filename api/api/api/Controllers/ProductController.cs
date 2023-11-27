using api.Executors.Commands;
using api.Executors.Commands.Product;
using api.Executors.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("product")]
public class ProductController : BaseApiController
{
	private readonly IMediator _mediator;

	public ProductController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("gets")]
	public async Task<IActionResult> GetProducts()
	{
		var result = await _mediator.Send(new GetProductQuery());
		return Ok(result);
	}

	[HttpGet("get/{Id}")]
	public async Task<IActionResult> GetCategoryById([FromRoute] GetProductByIdQuery query)
	{
		var result = await _mediator.Send(query);
		return Ok(result);
	}


	[HttpPost("create")]
	public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
	{
		var result = await _mediator.Send(command);
		return Ok(result);
	}

	[HttpDelete("delete/{Id}")]
	public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommand command)
	{
		var result = await _mediator.Send(command);
		return Ok(result);
	}

	[HttpPut("update/{Id}")]
	public async Task<IActionResult> UpdateProduct([FromRoute(Name = "Id")] long id,
		[FromBody] UpdateProductCommand command)
	{
		var result = await _mediator.Send(command with { Id = id });
		return Ok(result);
	}
}
