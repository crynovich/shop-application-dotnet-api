using MediatR;
using ProductsApplication.Features.Products.Persistence;

namespace ProductsApplication.Features.Products.Application.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repo;

        public DeleteProductHandler(IProductRepository repo) => _repo = repo;

        public async Task<Unit> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken
        )
        {
            await _repo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
