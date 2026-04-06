using MediatR;
using ProductsApplication.Features.Products.Domain;
using ProductsApplication.Features.Products.Persistence;

namespace ProductsApplication.Features.Products.Application.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repo;

        public UpdateProductHandler(IProductRepository repo) => _repo = repo;

        public async Task<Unit> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken
        )
        {
            if (request.Id != request.Product.Id)
                throw new ArgumentException("Id mismatch between route and payload");

            await _repo.UpdateAsync(request.Product);
            return Unit.Value;
        }
    }
}
