using MediatR;

namespace SmartProducts.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    decimal Price
) : IRequest<int>;