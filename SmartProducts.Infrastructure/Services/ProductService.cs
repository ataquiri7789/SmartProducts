using SmartProducts.Application.DTOs;
using SmartProducts.Application.Interfaces;
using SmartProducts.Domain.Entities;

namespace SmartProducts.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> CreateAsync(
        string name,
        decimal price,
        CancellationToken cancellationToken)
    {
        var product = new Product(name, price);

        return await _productRepository.CreateAsync(
            product,
            cancellationToken);
    }

    public async Task<List<ProductDto>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync(
            cancellationToken);
    }
}