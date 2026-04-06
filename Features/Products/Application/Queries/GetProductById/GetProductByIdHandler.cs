using MediatR;
using ProductsApplication.Features.Products.Domain;
using ProductsApplication.Features.Products.Persistence;

namespace ProductsApplication.Features.Products.Application.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly IProductRepository _repo;

        public GetProductByIdHandler(IProductRepository repo) => _repo = repo;

        public async Task<Product?> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
