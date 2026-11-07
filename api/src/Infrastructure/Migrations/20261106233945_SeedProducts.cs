using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "IsActive", "Name", "Slug" },
                values: new object[,]
                {
                    { (byte)1, true, "Men's", "mens" },
                    { (byte)2, true, "Women's", "womens" },
                    { (byte)3, true, "Beauty", "beauty" },
                    { (byte)4, true, "Home", "home" },
                    { (byte)5, true, "Kids", "kids" },
                    { (byte)6, true, "Office", "office" },
                    { (byte)7, true, "Electronics", "electronics" },
                    { (byte)8, true, "Curve", "curve" },
                    { (byte)9, true, "Jewelry", "jewelry" },
                    { (byte)10, true, "Sports", "sports" },
                    { (byte)11, true, "Bags", "bags" },
                    { (byte)12, true, "Toys", "toys" },
                    { (byte)13, true, "Seasonal", "seasonal" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "City", "CreatedAt", "IsActive", "Location", "Name" },
                values: new object[] { 1L, "Cape Town", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Plugg Demo Store" });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "EndDate", "IsActive", "Name", "StartDate", "StoreId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 10, 17, 20, 0, 0, 0, DateTimeKind.Utc), true, "Flash Sale", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 1L },
                    { 2L, new DateTime(2026, 10, 20, 20, 0, 0, 0, DateTimeKind.Utc), true, "Weekend Deals", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 1L }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "SubcategoryId", "CategoryId", "IsActive", "Name", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { (byte)1, (byte)2, true, "Dresses", "dresses", (byte)1 },
                    { (byte)2, (byte)2, true, "Suits & Corsets", "suits-corsets", (byte)2 },
                    { (byte)3, (byte)2, true, "Shoes", "shoes", (byte)3 },
                    { (byte)4, (byte)2, true, "Eyewear", "eyewear", (byte)4 },
                    { (byte)5, (byte)1, true, "Shirts & Tees", "shirts-tees", (byte)1 },
                    { (byte)6, (byte)1, true, "Footwear", "footwear", (byte)2 },
                    { (byte)7, (byte)1, true, "Watches", "watches", (byte)3 },
                    { (byte)8, (byte)11, true, "Handbags", "handbags", (byte)1 },
                    { (byte)9, (byte)11, true, "Backpacks", "backpacks", (byte)2 },
                    { (byte)10, (byte)9, true, "Earrings", "earrings", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedAt", "Description", "DiscountPercentage", "IsActive", "OriginalPrice", "Rating", "SaleId", "SalePrice", "StoreId", "SubcategoryId", "Title" },
                values: new object[,]
                {
                    { 1L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "An elegant floor-length gown in black, finished with a tailored silhouette for evening occasions.", 10, true, 129.99m, 3.6400000000000001, 1L, 116.99m, 1L, (byte)1, "Black Women's Gown" },
                    { 2L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A structured leather corset paired with a matching skirt for a bold, fitted look.", 16, true, 89.99m, 3.0499999999999998, 1L, 75.59m, 1L, (byte)2, "Corset Leather With Skirt" },
                    { 3L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A classic black corset top with a coordinating skirt, cinched at the waist.", 15, true, 79.99m, 4.5199999999999996, 1L, 67.99m, 1L, (byte)2, "Corset With Black Skirt" },
                    { 4L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A soft pea-green dress with a relaxed fit, perfect for everyday wear.", 18, true, 49.99m, 4.8799999999999999, 1L, 40.99m, 1L, (byte)1, "Dress Pea" },
                    { 5L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A striking red and black two-piece suit with sharp tailoring.", 19, true, 179.99m, 4.4800000000000004, 1L, 145.79m, 1L, (byte)2, "Marni Red & Black Suit" },
                    { 6L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A lightweight blue frock with a flattering A-line cut.", 12, true, 29.99m, 4.1699999999999999, 1L, 26.39m, 1L, (byte)1, "Blue Frock" },
                    { 7L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A breezy summer dress in a light fabric, ideal for warm days.", 19, true, 19.99m, 4.7699999999999996, 1L, 16.19m, 1L, (byte)1, "Girl Summer Dress" },
                    { 8L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A versatile grey dress that moves easily from day to evening.", 14, true, 34.99m, 2.7200000000000002, 1L, 30.09m, 1L, (byte)1, "Gray Dress" },
                    { 9L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A playful short frock with a fitted bodice and flared hem.", 13, true, 24.99m, 3.23, 1L, 21.74m, 1L, (byte)1, "Short Frock" },
                    { 10L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A tartan-print dress with a nipped waist and classic collar.", 13, true, 39.99m, 4.0499999999999998, 1L, 34.79m, 1L, (byte)1, "Tartan Dress" },
                    { 11L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Soft slip-on slippers in a black and brown colourway.", 3, true, 19.99m, 2.5299999999999998, 1L, 19.39m, 1L, (byte)3, "Black & Brown Slipper" },
                    { 12L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Pointed-toe heels from Calvin Klein with a sleek finish.", 3, true, 79.99m, 4.9199999999999999, 1L, 77.59m, 1L, (byte)3, "Calvin Klein Heel Shoes" },
                    { 13L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Metallic gold heels designed to catch the light at any event.", 14, true, 49.99m, 3.2599999999999998, 1L, 42.99m, 1L, (byte)3, "Golden Shoes Woman" },
                    { 14L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable everyday flats with a cushioned footbed.", 14, true, 29.99m, 3.0499999999999998, 1L, 25.79m, 1L, (byte)3, "Pampi Shoes" },
                    { 15L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Statement red shoes with a rounded toe and block heel.", 18, true, 34.99m, 3.25, 1L, 28.69m, 1L, (byte)3, "Red Shoes" },
                    { 16L, (byte)11, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A structured blue handbag with a top handle and adjustable strap.", 18, true, 49.99m, 2.9199999999999999, 1L, 40.99m, 1L, (byte)8, "Blue Women's Handbag" },
                    { 17L, (byte)11, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A genuine leather handbag from Heshe with a timeless silhouette.", 4, true, 129.99m, 4.9199999999999999, 1L, 124.79m, 1L, (byte)8, "Heshe Women's Leather Bag" },
                    { 18L, (byte)11, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A premium Prada handbag crafted for everyday luxury.", 14, true, 599.99m, 2.71, 1L, 515.99m, 1L, (byte)8, "Prada Women Bag" },
                    { 19L, (byte)11, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A white faux-leather backpack with padded straps for daily use.", 15, true, 39.99m, 3.3599999999999999, 1L, 33.99m, 1L, (byte)9, "White Faux Leather Backpack" },
                    { 20L, (byte)11, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A classic black handbag with a roomy interior and secure zip closure.", 12, true, 59.99m, 2.8900000000000001, 1L, 52.79m, 1L, (byte)8, "Women Handbag Black" },
                    { 21L, (byte)9, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Crystal drop earrings in a rich emerald green.", 15, true, 29.99m, 3.96, 1L, 25.49m, 1L, (byte)10, "Green Crystal Earring" },
                    { 22L, (byte)9, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Oval-cut green stone earrings with a delicate gold-tone setting.", 15, true, 24.99m, 3.5699999999999998, 1L, 21.24m, 1L, (byte)10, "Green Oval Earring" },
                    { 23L, (byte)9, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Statement earrings with a tropical-inspired design.", 1, true, 19.99m, 4.4000000000000004, 2L, 19.79m, 1L, (byte)10, "Tropical Earring" },
                    { 24L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Classic black sunglasses with UV-protective lenses.", 5, true, 29.99m, 4.4100000000000001, 2L, 28.49m, 1L, (byte)4, "Black Sun Glasses" },
                    { 25L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Timeless sunglasses with a rounded frame.", 5, true, 24.99m, 3.8599999999999999, 2L, 23.74m, 1L, (byte)4, "Classic Sun Glasses" },
                    { 26L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Two-tone sunglasses in green and black with a modern frame.", 1, true, 34.99m, 4.5499999999999998, 2L, 34.64m, 1L, (byte)4, "Green and Black Glasses" },
                    { 27L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Statement sunglasses with a bold frame, made for standing out.", 11, true, 19.99m, 2.79, 2L, 17.79m, 1L, (byte)4, "Party Glasses" },
                    { 28L, (byte)2, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Everyday sunglasses with a lightweight frame.", 2, true, 22.99m, 3.02, 2L, 22.53m, 1L, (byte)4, "Sunglasses" },
                    { 29L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A checked shirt in blue and black, cut for a relaxed everyday fit.", 15, true, 29.99m, 3.6400000000000001, 2L, 25.49m, 1L, (byte)5, "Blue & Black Check Shirt" },
                    { 30L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A graphic Aorus-branded t-shirt in soft cotton.", 1, true, 24.99m, 3.1800000000000002, 2L, 24.74m, 1L, (byte)5, "Gigabyte Aorus Men Tshirt" },
                    { 31L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A classic plaid shirt with a button-down collar.", 20, true, 34.99m, 3.46, 2L, 27.99m, 1L, (byte)5, "Man Plaid Shirt" },
                    { 32L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A lightweight short-sleeve shirt for warm-weather wear.", 7, true, 19.99m, 2.8999999999999999, 2L, 18.59m, 1L, (byte)5, "Man Short Sleeve Shirt" },
                    { 33L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A checked button-up shirt with a tailored fit.", 11, true, 27.99m, 2.7200000000000002, 2L, 24.91m, 1L, (byte)5, "Men Check Shirt" },
                    { 34L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Iconic Air Jordan 1 sneakers in a red and black colourway.", 4, true, 149.99m, 4.7699999999999996, 2L, 143.99m, 1L, (byte)6, "Nike Air Jordan 1 Red And Black" },
                    { 35L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Performance baseball cleats built for grip and speed.", 18, true, 79.99m, 3.8799999999999999, 2L, 65.59m, 1L, (byte)6, "Nike Baseball Cleats" },
                    { 36L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Retro-styled Puma trainers with a cushioned sole.", 4, true, 89.99m, 4.9000000000000004, 2L, 86.39m, 1L, (byte)6, "Puma Future Rider Trainers" },
                    { 37L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight sneakers in off-white and red, built for everyday training.", 5, true, 119.99m, 4.7699999999999996, 2L, 113.99m, 1L, (byte)6, "Sports Sneakers Off White & Red" },
                    { 38L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A low-top sneaker in off-white with red accents.", null, true, 109.99m, 4.6900000000000004, null, null, 1L, (byte)6, "Sports Sneakers Off White Red" },
                    { 39L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A classic watch with a brown leather strap and minimalist dial.", 6, true, 89.99m, 4.1900000000000004, 2L, 84.59m, 1L, (byte)7, "Brown Leather Belt Watch" },
                    { 40L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A Longines Master Collection watch with a refined, understated face.", 17, true, 1499.99m, 3.8700000000000001, 2L, 1244.99m, 1L, (byte)7, "Longines Master Collection" },
                    { 41L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A Rolex Cellini with a black dial and date function.", 9, true, 8999.99m, 4.9699999999999998, 2L, 8189.99m, 1L, (byte)7, "Rolex Cellini Date Black Dial" },
                    { 42L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A Rolex Cellini Moonphase with an intricate dial complication.", 18, true, 12999.99m, 2.5800000000000001, 2L, 10659.99m, 1L, (byte)7, "Rolex Cellini Moonphase" },
                    { 43L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A Rolex Datejust, the brand's most recognisable classic.", 4, true, 10999.99m, 3.6600000000000001, 2L, 10559.99m, 1L, (byte)7, "Rolex Datejust" },
                    { 44L, (byte)1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "A Rolex Submariner built for durability and timeless style.", 5, true, 13999.99m, 2.6899999999999999, 2L, 13299.99m, 1L, (byte)7, "Rolex Submariner Watch" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductId", "SortOrder" },
                values: new object[,]
                {
                    { 1L, "https://cdn.dummyjson.com/product-images/womens-dresses/black-women's-gown/thumbnail.webp", 1L, 0 },
                    { 2L, "https://cdn.dummyjson.com/product-images/womens-dresses/black-women's-gown/1.webp", 1L, 1 },
                    { 3L, "https://cdn.dummyjson.com/product-images/womens-dresses/corset-leather-with-skirt/thumbnail.webp", 2L, 0 },
                    { 4L, "https://cdn.dummyjson.com/product-images/womens-dresses/corset-with-black-skirt/thumbnail.webp", 3L, 0 },
                    { 5L, "https://cdn.dummyjson.com/product-images/womens-dresses/dress-pea/thumbnail.webp", 4L, 0 },
                    { 6L, "https://cdn.dummyjson.com/product-images/womens-dresses/marni-red-&-black-suit/thumbnail.webp", 5L, 0 },
                    { 7L, "https://cdn.dummyjson.com/product-images/tops/blue-frock/thumbnail.webp", 6L, 0 },
                    { 8L, "https://cdn.dummyjson.com/product-images/tops/girl-summer-dress/thumbnail.webp", 7L, 0 },
                    { 9L, "https://cdn.dummyjson.com/product-images/tops/gray-dress/thumbnail.webp", 8L, 0 },
                    { 10L, "https://cdn.dummyjson.com/product-images/tops/short-frock/thumbnail.webp", 9L, 0 },
                    { 11L, "https://cdn.dummyjson.com/product-images/tops/tartan-dress/thumbnail.webp", 10L, 0 },
                    { 12L, "https://cdn.dummyjson.com/product-images/womens-shoes/black-&-brown-slipper/thumbnail.webp", 11L, 0 },
                    { 13L, "https://cdn.dummyjson.com/product-images/womens-shoes/calvin-klein-heel-shoes/thumbnail.webp", 12L, 0 },
                    { 14L, "https://cdn.dummyjson.com/product-images/womens-shoes/golden-shoes-woman/thumbnail.webp", 13L, 0 },
                    { 15L, "https://cdn.dummyjson.com/product-images/womens-shoes/pampi-shoes/thumbnail.webp", 14L, 0 },
                    { 16L, "https://cdn.dummyjson.com/product-images/womens-shoes/red-shoes/thumbnail.webp", 15L, 0 },
                    { 17L, "https://cdn.dummyjson.com/product-images/womens-bags/blue-women's-handbag/thumbnail.webp", 16L, 0 },
                    { 18L, "https://cdn.dummyjson.com/product-images/womens-bags/heshe-women's-leather-bag/thumbnail.webp", 17L, 0 },
                    { 19L, "https://cdn.dummyjson.com/product-images/womens-bags/prada-women-bag/thumbnail.webp", 18L, 0 },
                    { 20L, "https://cdn.dummyjson.com/product-images/womens-bags/prada-women-bag/1.webp", 18L, 1 },
                    { 21L, "https://cdn.dummyjson.com/product-images/womens-bags/white-faux-leather-backpack/thumbnail.webp", 19L, 0 },
                    { 22L, "https://cdn.dummyjson.com/product-images/womens-bags/women-handbag-black/thumbnail.webp", 20L, 0 },
                    { 23L, "https://cdn.dummyjson.com/product-images/womens-jewellery/green-crystal-earring/thumbnail.webp", 21L, 0 },
                    { 24L, "https://cdn.dummyjson.com/product-images/womens-jewellery/green-oval-earring/thumbnail.webp", 22L, 0 },
                    { 25L, "https://cdn.dummyjson.com/product-images/womens-jewellery/tropical-earring/thumbnail.webp", 23L, 0 },
                    { 26L, "https://cdn.dummyjson.com/product-images/sunglasses/black-sun-glasses/thumbnail.webp", 24L, 0 },
                    { 27L, "https://cdn.dummyjson.com/product-images/sunglasses/black-sun-glasses/1.webp", 24L, 1 },
                    { 28L, "https://cdn.dummyjson.com/product-images/sunglasses/classic-sun-glasses/thumbnail.webp", 25L, 0 },
                    { 29L, "https://cdn.dummyjson.com/product-images/sunglasses/green-and-black-glasses/thumbnail.webp", 26L, 0 },
                    { 30L, "https://cdn.dummyjson.com/product-images/sunglasses/party-glasses/thumbnail.webp", 27L, 0 },
                    { 31L, "https://cdn.dummyjson.com/product-images/sunglasses/sunglasses/thumbnail.webp", 28L, 0 },
                    { 32L, "https://cdn.dummyjson.com/product-images/mens-shirts/blue-&-black-check-shirt/thumbnail.webp", 29L, 0 },
                    { 33L, "https://cdn.dummyjson.com/product-images/mens-shirts/gigabyte-aorus-men-tshirt/thumbnail.webp", 30L, 0 },
                    { 34L, "https://cdn.dummyjson.com/product-images/mens-shirts/man-plaid-shirt/thumbnail.webp", 31L, 0 },
                    { 35L, "https://cdn.dummyjson.com/product-images/mens-shirts/man-short-sleeve-shirt/thumbnail.webp", 32L, 0 },
                    { 36L, "https://cdn.dummyjson.com/product-images/mens-shirts/men-check-shirt/thumbnail.webp", 33L, 0 },
                    { 37L, "https://cdn.dummyjson.com/product-images/mens-shoes/nike-air-jordan-1-red-and-black/thumbnail.webp", 34L, 0 },
                    { 38L, "https://cdn.dummyjson.com/product-images/mens-shoes/nike-air-jordan-1-red-and-black/1.webp", 34L, 1 },
                    { 39L, "https://cdn.dummyjson.com/product-images/mens-shoes/nike-baseball-cleats/thumbnail.webp", 35L, 0 },
                    { 40L, "https://cdn.dummyjson.com/product-images/mens-shoes/puma-future-rider-trainers/thumbnail.webp", 36L, 0 },
                    { 41L, "https://cdn.dummyjson.com/product-images/mens-shoes/sports-sneakers-off-white-&-red/thumbnail.webp", 37L, 0 },
                    { 42L, "https://cdn.dummyjson.com/product-images/mens-shoes/sports-sneakers-off-white-red/thumbnail.webp", 38L, 0 },
                    { 43L, "https://cdn.dummyjson.com/product-images/mens-watches/brown-leather-belt-watch/thumbnail.webp", 39L, 0 },
                    { 44L, "https://cdn.dummyjson.com/product-images/mens-watches/longines-master-collection/thumbnail.webp", 40L, 0 },
                    { 45L, "https://cdn.dummyjson.com/product-images/mens-watches/rolex-cellini-date-black-dial/thumbnail.webp", 41L, 0 },
                    { 46L, "https://cdn.dummyjson.com/product-images/mens-watches/rolex-cellini-date-black-dial/1.webp", 41L, 1 },
                    { 47L, "https://cdn.dummyjson.com/product-images/mens-watches/rolex-cellini-moonphase/thumbnail.webp", 42L, 0 },
                    { 48L, "https://cdn.dummyjson.com/product-images/mens-watches/rolex-datejust/thumbnail.webp", 43L, 0 },
                    { 49L, "https://cdn.dummyjson.com/product-images/mens-watches/rolex-submariner-watch/thumbnail.webp", 44L, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductSizeId", "ProductId", "Quantity", "Size", "UnitsSold" },
                values: new object[,]
                {
                    { 1L, 1L, 20, "XS", 0 },
                    { 2L, 1L, 20, "S", 0 },
                    { 3L, 1L, 20, "M", 0 },
                    { 4L, 1L, 20, "L", 0 },
                    { 5L, 1L, 20, "XL", 0 },
                    { 6L, 2L, 20, "XS", 0 },
                    { 7L, 2L, 20, "S", 0 },
                    { 8L, 2L, 20, "M", 0 },
                    { 9L, 2L, 20, "L", 0 },
                    { 10L, 2L, 20, "XL", 0 },
                    { 11L, 3L, 20, "XS", 0 },
                    { 12L, 3L, 20, "S", 0 },
                    { 13L, 3L, 20, "M", 0 },
                    { 14L, 3L, 20, "L", 0 },
                    { 15L, 3L, 20, "XL", 0 },
                    { 16L, 4L, 20, "XS", 0 },
                    { 17L, 4L, 20, "S", 0 },
                    { 18L, 4L, 20, "M", 0 },
                    { 19L, 4L, 20, "L", 0 },
                    { 20L, 4L, 20, "XL", 0 },
                    { 21L, 5L, 20, "XS", 0 },
                    { 22L, 5L, 20, "S", 0 },
                    { 23L, 5L, 20, "M", 0 },
                    { 24L, 5L, 20, "L", 0 },
                    { 25L, 5L, 20, "XL", 0 },
                    { 26L, 6L, 20, "XS", 0 },
                    { 27L, 6L, 20, "S", 0 },
                    { 28L, 6L, 20, "M", 0 },
                    { 29L, 6L, 20, "L", 0 },
                    { 30L, 6L, 20, "XL", 0 },
                    { 31L, 7L, 20, "XS", 0 },
                    { 32L, 7L, 20, "S", 0 },
                    { 33L, 7L, 20, "M", 0 },
                    { 34L, 7L, 20, "L", 0 },
                    { 35L, 7L, 20, "XL", 0 },
                    { 36L, 8L, 20, "XS", 0 },
                    { 37L, 8L, 20, "S", 0 },
                    { 38L, 8L, 20, "M", 0 },
                    { 39L, 8L, 20, "L", 0 },
                    { 40L, 8L, 20, "XL", 0 },
                    { 41L, 9L, 20, "XS", 0 },
                    { 42L, 9L, 20, "S", 0 },
                    { 43L, 9L, 20, "M", 0 },
                    { 44L, 9L, 20, "L", 0 },
                    { 45L, 9L, 20, "XL", 0 },
                    { 46L, 10L, 20, "XS", 0 },
                    { 47L, 10L, 20, "S", 0 },
                    { 48L, 10L, 20, "M", 0 },
                    { 49L, 10L, 20, "L", 0 },
                    { 50L, 10L, 20, "XL", 0 },
                    { 51L, 11L, 20, "6", 0 },
                    { 52L, 11L, 20, "7", 0 },
                    { 53L, 11L, 20, "8", 0 },
                    { 54L, 11L, 20, "9", 0 },
                    { 55L, 11L, 20, "10", 0 },
                    { 56L, 11L, 20, "11", 0 },
                    { 57L, 12L, 20, "6", 0 },
                    { 58L, 12L, 20, "7", 0 },
                    { 59L, 12L, 20, "8", 0 },
                    { 60L, 12L, 20, "9", 0 },
                    { 61L, 12L, 20, "10", 0 },
                    { 62L, 12L, 20, "11", 0 },
                    { 63L, 13L, 20, "6", 0 },
                    { 64L, 13L, 20, "7", 0 },
                    { 65L, 13L, 20, "8", 0 },
                    { 66L, 13L, 20, "9", 0 },
                    { 67L, 13L, 20, "10", 0 },
                    { 68L, 13L, 20, "11", 0 },
                    { 69L, 14L, 20, "6", 0 },
                    { 70L, 14L, 20, "7", 0 },
                    { 71L, 14L, 20, "8", 0 },
                    { 72L, 14L, 20, "9", 0 },
                    { 73L, 14L, 20, "10", 0 },
                    { 74L, 14L, 20, "11", 0 },
                    { 75L, 15L, 20, "6", 0 },
                    { 76L, 15L, 20, "7", 0 },
                    { 77L, 15L, 20, "8", 0 },
                    { 78L, 15L, 20, "9", 0 },
                    { 79L, 15L, 20, "10", 0 },
                    { 80L, 15L, 20, "11", 0 },
                    { 81L, 16L, 20, "One Size", 0 },
                    { 82L, 17L, 20, "One Size", 0 },
                    { 83L, 18L, 20, "One Size", 0 },
                    { 84L, 19L, 20, "One Size", 0 },
                    { 85L, 20L, 20, "One Size", 0 },
                    { 86L, 21L, 20, "One Size", 0 },
                    { 87L, 22L, 20, "One Size", 0 },
                    { 88L, 23L, 20, "One Size", 0 },
                    { 89L, 24L, 20, "One Size", 0 },
                    { 90L, 25L, 20, "One Size", 0 },
                    { 91L, 26L, 20, "One Size", 0 },
                    { 92L, 27L, 20, "One Size", 0 },
                    { 93L, 28L, 20, "One Size", 0 },
                    { 94L, 29L, 20, "XS", 0 },
                    { 95L, 29L, 20, "S", 0 },
                    { 96L, 29L, 20, "M", 0 },
                    { 97L, 29L, 20, "L", 0 },
                    { 98L, 29L, 20, "XL", 0 },
                    { 99L, 30L, 20, "XS", 0 },
                    { 100L, 30L, 20, "S", 0 },
                    { 101L, 30L, 20, "M", 0 },
                    { 102L, 30L, 20, "L", 0 },
                    { 103L, 30L, 20, "XL", 0 },
                    { 104L, 31L, 20, "XS", 0 },
                    { 105L, 31L, 20, "S", 0 },
                    { 106L, 31L, 20, "M", 0 },
                    { 107L, 31L, 20, "L", 0 },
                    { 108L, 31L, 20, "XL", 0 },
                    { 109L, 32L, 20, "XS", 0 },
                    { 110L, 32L, 20, "S", 0 },
                    { 111L, 32L, 20, "M", 0 },
                    { 112L, 32L, 20, "L", 0 },
                    { 113L, 32L, 20, "XL", 0 },
                    { 114L, 33L, 20, "XS", 0 },
                    { 115L, 33L, 20, "S", 0 },
                    { 116L, 33L, 20, "M", 0 },
                    { 117L, 33L, 20, "L", 0 },
                    { 118L, 33L, 20, "XL", 0 },
                    { 119L, 34L, 20, "6", 0 },
                    { 120L, 34L, 20, "7", 0 },
                    { 121L, 34L, 20, "8", 0 },
                    { 122L, 34L, 20, "9", 0 },
                    { 123L, 34L, 20, "10", 0 },
                    { 124L, 34L, 20, "11", 0 },
                    { 125L, 34L, 20, "12", 0 },
                    { 126L, 35L, 20, "6", 0 },
                    { 127L, 35L, 20, "7", 0 },
                    { 128L, 35L, 20, "8", 0 },
                    { 129L, 35L, 20, "9", 0 },
                    { 130L, 35L, 20, "10", 0 },
                    { 131L, 35L, 20, "11", 0 },
                    { 132L, 35L, 20, "12", 0 },
                    { 133L, 36L, 20, "6", 0 },
                    { 134L, 36L, 20, "7", 0 },
                    { 135L, 36L, 20, "8", 0 },
                    { 136L, 36L, 20, "9", 0 },
                    { 137L, 36L, 20, "10", 0 },
                    { 138L, 36L, 20, "11", 0 },
                    { 139L, 36L, 20, "12", 0 },
                    { 140L, 37L, 20, "6", 0 },
                    { 141L, 37L, 20, "7", 0 },
                    { 142L, 37L, 20, "8", 0 },
                    { 143L, 37L, 20, "9", 0 },
                    { 144L, 37L, 20, "10", 0 },
                    { 145L, 37L, 20, "11", 0 },
                    { 146L, 37L, 20, "12", 0 },
                    { 147L, 38L, 20, "6", 0 },
                    { 148L, 38L, 20, "7", 0 },
                    { 149L, 38L, 20, "8", 0 },
                    { 150L, 38L, 20, "9", 0 },
                    { 151L, 38L, 20, "10", 0 },
                    { 152L, 38L, 20, "11", 0 },
                    { 153L, 38L, 20, "12", 0 },
                    { 154L, 39L, 20, "One Size", 0 },
                    { 155L, 40L, 20, "One Size", 0 },
                    { 156L, 41L, 20, "One Size", 0 },
                    { 157L, 42L, 20, "One Size", 0 },
                    { 158L, 43L, 20, "One Size", 0 },
                    { 159L, 44L, 20, "One Size", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "ProductSizeId",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryId",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 1L);
        }
    }
}
