using Application.Products;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products;

public class ProductQueryService(ApiDbContext dbContext) : IProductQueryService
{
    public async Task<IReadOnlyList<ProductDto>> GetProductsAsync(
        string? category = null,
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.Products
            .Include(p => p.Store)
            .Include(p => p.Category)
            .Include(p => p.Subcategory)
            .Include(p => p.Images)
            .Include(p => p.Sale)
            .Include(p => p.Sizes)
            .Where(p => p.IsActive);

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(p => p.Category.Slug == category);
        }

        var products = await query
            .OrderByDescending(p => p.Rating)
            .AsSplitQuery()
            .ToListAsync(cancellationToken);

        return products.Select(ProductMapper.ToDto).ToList();
    }
}
