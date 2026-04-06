using MediatR;
using ProductsApplication.Features.Products.Domain;

namespace ProductsApplication.Features.Products.Application.Queries.ListProducts
{
    public record ListProductsQuery() : IRequest<IEnumerable<Product>>;
}
