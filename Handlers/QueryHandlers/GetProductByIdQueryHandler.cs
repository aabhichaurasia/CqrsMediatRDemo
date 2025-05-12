using CqrsMediatRDemo.CQRS.Queries;
using CqrsMediatRDemo.Models;
using CqrsMediatRDemo.Repositories;
using MediatR;

namespace CqrsMediatRDemo.Handlers.QueryHandlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly IProductRepository _repo;

    public GetProductByIdQueryHandler(IProductRepository repo) => _repo = repo;

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _repo.GetByIdAsync(request.Id);
}
