using CqrsMediatRDemo.Models;
using MediatR;

namespace CqrsMediatRDemo.CQRS.Queries;

public class GetAllProductsQuery : IRequest<List<Product>> { }
