using MediatR;

namespace ProductsApplication.Features.Products.Application.Commands.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest;
}
