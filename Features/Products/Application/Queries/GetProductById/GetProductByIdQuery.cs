using MediatR;
using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Products.Application.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<Product?>;
}
