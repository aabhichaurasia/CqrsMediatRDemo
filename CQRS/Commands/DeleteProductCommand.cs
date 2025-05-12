using MediatR;

namespace CqrsMediatRDemo.CQRS.Commands;

public class DeleteProductCommand : IRequest
{
    public Guid Id { get; set; }
}
