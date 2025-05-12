using CqrsMediatRDemo.Models;
using MediatR;

namespace CqrsMediatRDemo.CQRS.Commands;

public class UpdateProductCommand : IRequest<Product?>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}
