using SmartProducts.Domain.Common;

namespace SmartProducts.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    private Product()
    {
    }

    public Product(string name, decimal price)
    {
        SetName(name);
        SetPrice(price);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre es obligatorio.");

        if (name.Length > 100)
            throw new ArgumentException("El nombre no puede exceder 100 caracteres.");

        Name = name;
        SetUpdatedAt();
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("El precio debe ser mayor que cero.");

        Price = price;
        SetUpdatedAt();
    }
}