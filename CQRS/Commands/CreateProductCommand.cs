using CqrsMediatRDemo.Models;
using MediatR;

namespace CqrsMediatRDemo.CQRS.Commands;

public class CreateProductCommand : IRequest<Product>
{
    public string? Name { get; set; } 
    public decimal Price { get; set; }
}
