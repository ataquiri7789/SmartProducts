using MediatR;
using SmartProducts.Application.DTOs;
using SmartProducts.Application.Interfaces;

namespace SmartProducts.Application.Features.Products.Queries.GetProducts;

public class GetProductsHandler
    : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductService _productService;

    public GetProductsHandler(IProductService productService)
    {
        _productService = productService;
    }

    public Task<List<ProductDto>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        return _productService.GetAllAsync(cancellationToken);
    }
}