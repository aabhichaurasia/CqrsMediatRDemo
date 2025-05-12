using CqrsMediatRDemo.CQRS.Commands;
using CqrsMediatRDemo.Models;
using CqrsMediatRDemo.Repositories;
using MediatR;

namespace CqrsMediatRDemo.Handlers.CommandHandlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _repo;

    public CreateProductCommandHandler(IProductRepository repo) => _repo = repo;

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price
        };

        await _repo.AddAsync(product);
        return product;
    }
}
