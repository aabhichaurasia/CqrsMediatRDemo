using CqrsMediatRDemo.CQRS.Commands;
using CqrsMediatRDemo.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatRDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _mediator.Send(new GetAllProductsQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var product = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id) return BadRequest();

        var updated = await _mediator.Send(command);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteProductCommand { Id = id });
        return NoContent();
    }
}
