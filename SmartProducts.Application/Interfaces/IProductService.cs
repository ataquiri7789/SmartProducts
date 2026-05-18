using SmartProducts.Application.DTOs;

namespace SmartProducts.Application.Interfaces;

public interface IProductService
{
    Task<int> CreateAsync(
        string name,
        decimal price,
        CancellationToken cancellationToken);

    Task<List<ProductDto>> GetAllAsync(
        CancellationToken cancellationToken);
}