using MediatR;
using SmartProducts.Application.DTOs;

namespace SmartProducts.Application.Features.Products.Queries.GetProducts;

public record GetProductsQuery()
    : IRequest<List<ProductDto>>;