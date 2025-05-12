using CqrsMediatRDemo.CQRS.Commands;
using CqrsMediatRDemo.Repositories;
using MediatR;

namespace CqrsMediatRDemo.Handlers.CommandHandlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _repo;

    public DeleteProductCommandHandler(IProductRepository repo) => _repo = repo;

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
