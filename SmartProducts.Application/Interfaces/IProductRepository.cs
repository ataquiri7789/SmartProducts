using SmartProducts.Application.DTOs;
using SmartProducts.Domain.Entities;

namespace SmartProducts.Application.Interfaces;

public interface IProductRepository
{
    Task<int> CreateAsync(
        Product product,
        CancellationToken cancellationToken);

    Task<List<ProductDto>> GetAllAsync(
        CancellationToken cancellationToken);
}