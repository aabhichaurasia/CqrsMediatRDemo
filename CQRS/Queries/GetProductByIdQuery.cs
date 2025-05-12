using CqrsMediatRDemo.Models;
using MediatR;

namespace CqrsMediatRDemo.CQRS.Queries;

public class GetProductByIdQuery : IRequest<Product?>
{
    public Guid Id { get; set; }
}
