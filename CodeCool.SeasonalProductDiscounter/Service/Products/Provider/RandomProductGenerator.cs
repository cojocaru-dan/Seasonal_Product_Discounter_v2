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
    public double MinProductPrice { get; }
    public double MaxProductPrice { get; }
    public RandomProductGenerator(uint count, double minimumPrice, double maximumPrice)
    {
        Products = GenerateRandomProducts(count, minimumPrice, maximumPrice).ToList();
        MinProductPrice = minimumPrice;
        MaxProductPrice = maximumPrice;
    }

    private static IEnumerable<Product> GenerateRandomProducts(uint count, double minimumPrice, double maximumPrice)
    {
        List<Product> products = new List<Product>();
        if (maximumPrice <= minimumPrice) return products;
        for (int i = 0; i < count; i++)
        {
            uint id = (uint)i;
            Color color = GetRandomColor();
            string name = GetRandomName(color);
            Season season = GetRandomSeason();
            double price = GetRandomPrice(minimumPrice, maximumPrice);
            Product newProduct = new Product(id, name, color, season, price);
            products.Add(newProduct);
        }
        return products;
    }

    private static Color GetRandomColor()
    {
        return Colors[Random.Next(Colors.Length)];
    }

    private static string GetRandomName(Color color)
    {
        return color.ToString() + " " + Names[Random.Next(Names.Length)];
    }

    private static Season GetRandomSeason()
    {
        return Seasons[Random.Next(Seasons.Length)]; ;
    }

    private static double GetRandomPrice(double minimumPrice, double maximumPrice)
    {
        return Random.NextDouble(minimumPrice, maximumPrice);
    }
}
