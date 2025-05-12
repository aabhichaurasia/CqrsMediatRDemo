using CqrsMediatRDemo.CQRS.Queries;
using CqrsMediatRDemo.Models;
using CqrsMediatRDemo.Repositories;
using MediatR;

namespace CqrsMediatRDemo.Handlers.QueryHandlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly IProductRepository _repo;

    public GetAllProductsQueryHandler(IProductRepository repo) => _repo = repo;

    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) =>
        await _repo.GetAllAsync();
}
