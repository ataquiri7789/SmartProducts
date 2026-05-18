using Microsoft.EntityFrameworkCore;
using SmartProducts.Application.DTOs;
using SmartProducts.Application.Interfaces;
using SmartProducts.Domain.Entities;
using SmartProducts.Infrastructure.Persistence;

namespace SmartProducts.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(
        Product product,
        CancellationToken cancellationToken)
    {
        _context.Products.Add(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public async Task<List<ProductDto>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.Products
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }
}