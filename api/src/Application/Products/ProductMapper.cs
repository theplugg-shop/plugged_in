using Domain.Entities;

namespace Application.Products;

public static class ProductMapper
{
    public static ProductDto ToDto(Product p) => new()
    {
        ProductId = p.ProductId,
        Title = p.Title,
        Description = p.Description,
        CategoryId = p.CategoryId,
        CategorySlug = p.Category.Slug,
        CategoryName = p.Category.Name,
        SubcategorySlug = p.Subcategory?.Slug,
        SubcategoryName = p.Subcategory?.Name,
        Sizes = p.Sizes.Select(s => new ProductSizeDto { Size = s.Size, Quantity = s.Quantity, UnitsSold = s.UnitsSold }).ToList(),
        OriginalPrice = p.OriginalPrice,
        SalePrice = p.SalePrice,
        DiscountPercentage = p.DiscountPercentage,
        IsOnSale = p.SalePrice != null && p.SalePrice < p.OriginalPrice,
        SaleEndsAt = p.Sale != null ? p.Sale.EndDate : null,
        Rating = p.Rating,
        Images = p.Images.OrderBy(i => i.SortOrder).Select(i => i.ImageUrl).ToList(),
        StoreId = p.StoreId,
        StoreName = p.Store.Name,
    };
}
