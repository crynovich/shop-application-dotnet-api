using MediatR;
using ProductsApplication.Features.Products.Domain;
using ProductsApplication.Features.Products.Persistence;

namespace ProductsApplication.Features.Products.Application.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repo;

        public CreateProductHandler(IProductRepository repo) => _repo = repo;

        public async Task<int> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken
        )
        {
            var p = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                SupplierId = request.SupplierId,
                CategoryId = request.CategoryId,
            };

            await _repo.AddAsync(p);
            return p.Id;
        }
    }
}
