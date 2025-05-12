using CqrsMediatRDemo.CQRS.Commands;
using CqrsMediatRDemo.Models;
using CqrsMediatRDemo.Repositories;
using MediatR;

namespace CqrsMediatRDemo.Handlers.CommandHandlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product?>
{
    private readonly IProductRepository _repo;

    public UpdateProductCommandHandler(IProductRepository repo) => _repo = repo;

    public async Task<Product?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repo.GetByIdAsync(request.Id);
        if (product == null) return null;

        product.Name = request.Name;
        product.Price = request.Price;

        await _repo.UpdateAsync(product);
        return product;
    }
}

