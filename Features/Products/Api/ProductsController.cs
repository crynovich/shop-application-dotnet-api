using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductsApplication.Features.Products.Domain;
using ProductsApplication.Features.Products.Application.Commands.CreateProduct;
using ProductsApplication.Features.Products.Application.Commands.DeleteProduct;
using ProductsApplication.Features.Products.Application.Commands.UpdateProduct;
using ProductsApplication.Features.Products.Application.Queries.GetProductById;
using ProductsApplication.Features.Products.Application.Queries.ListProducts;

namespace ProductsApplication.Features.Products.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _mediator.Send(
                new ListProductsQuery()
            );
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _mediator.Send(
                new GetProductByIdQuery(id)
            );
            if (item is null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await _mediator.Send(
                new UpdateProductCommand(id, product)
            );
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
