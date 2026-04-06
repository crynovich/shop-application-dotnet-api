using MediatR;

namespace ProductsApplication.Features.Products.Application.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string? Description,
        decimal Price,
        int? SupplierId,
        int? CategoryId
    ) : IRequest<int>;
}
