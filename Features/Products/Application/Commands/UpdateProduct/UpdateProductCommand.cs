using MediatR;
using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Products.Application.Commands.UpdateProduct
{
    public record UpdateProductCommand(int Id, Product Product) : IRequest;
}
