using MediatR;
using SmartProducts.Application.Interfaces;

namespace SmartProducts.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler
    : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductService _productService;

    public CreateProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public Task<int> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        return _productService.CreateAsync(
            request.Name,
            request.Price,
            cancellationToken);
    }
}