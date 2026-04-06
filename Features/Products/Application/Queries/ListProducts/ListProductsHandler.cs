using MediatR;
using ProductsApplication.Features.Products.Domain;
using ProductsApplication.Features.Products.Persistence;

namespace ProductsApplication.Features.Products.Application.Queries.ListProducts
{
    public class ListProductsHandler : IRequestHandler<ListProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repo;

        public ListProductsHandler(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<Product>> Handle(
            ListProductsQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _repo.ListAsync();
        }
    }
}
