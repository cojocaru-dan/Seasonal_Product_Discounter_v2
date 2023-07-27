using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

public class ProductProvider : IProductProvider
{
    public IEnumerable<Product> Products { get; }

    public ProductProvider()
    {
        Products = GetProducts();
    }

    private static IEnumerable<Product> GetProducts()
    {
        return new List<Product>
        {
            new(1, "Yellow skirt", Color.Yellow, Season.Spring, 15.00),
            new(2, "Blue skirt", Color.Blue, Season.Spring, 15.00),
            new(3, "Red T-Shirt", Color.Red, Season.Summer, 10.00),
            new(4,"Brown T-Shirt", Color.Brown, Season.Summer, 10.00),
            new(5,"Brown jacket", Color.Brown, Season.Autumn, 40.00),
            new(6,"Violet shirt", Color.Violet, Season.Autumn, 30.00),
            new(7,"Blue jacket", Color.Blue, Season.Autumn, 40.00),
            new(8,"Blue hat", Color.Blue, Season.Winter, 10.00),
            new(9,"Pink hat", Color.Pink, Season.Winter, 10.00),
            new(10,"Red gloves", Color.Red, Season.Winter, 8.00),
            new(11,"Yellow gloves", Color.Yellow, Season.Winter, 8.00)
        };
    }
}
