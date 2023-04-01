using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;


namespace CleanArch.Domain.CommandsHandlers
{
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public ProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // business logic will be here like sent email
            Product product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
            };
            _productRepository.Add(product);

            return Task.FromResult(true);
        }
    }
}
