using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

public class RandomProductGenerator : IProductProvider
{
    private static readonly Random Random = new();
    private static readonly Color[] Colors = Enum.GetValues<Color>();
    private static readonly Season[] Seasons = Enum.GetValues<Season>();

    private static readonly string[] Names =
    {
        "skirt",
        "T-shirt",
        "jacket",
        "shirt",
        "hat",
        "gloves"
    };

    public IEnumerable<Product> Products { get; }

    public RandomProductGenerator(uint count, double minimumPrice, double maximumPrice)
    {
        Products = GenerateRandomProducts(count, minimumPrice, maximumPrice).ToList();
    }

    private static IEnumerable<Product> GenerateRandomProducts(uint count, double minimumPrice, double maximumPrice)
    {
        return default;
    }

    private static Color GetRandomColor()
    {
        return default;
    }

    private static string GetRandomName(Color color)
    {
        return default;
    }

    private static Season GetRandomSeason()
    {
        return default;
    }

    private static double GetRandomPrice(double minimumPrice, double maximumPrice)
    {
        return default;
    }
}
