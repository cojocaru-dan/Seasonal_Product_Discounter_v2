using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

public interface IProductStatistics
{
    Product? GetMostExpensive();
    Product? GetCheapest();
    double GetAveragePrice();

    Dictionary<string, double> GetAveragePricesByName();
    Dictionary<Color, double> GetAveragePricesByColor();
    Dictionary<Season, double> GetAveragePricesBySeason();

    /// <summary>
    /// Gets the average prices for three equal sized prince ranges (cheap, average, expensive) by looking at the difference between the cheapest and the most expensive products.
    /// </summary>
    /// <returns></returns>
    Dictionary<PriceRange, double> GetAveragePricesByPriceRange();

    Dictionary<string, int> GetCountByName();
    Dictionary<Color, int> GetCountByColor();
    Dictionary<Season, int> GetCountBySeason();

    /// <summary>
    /// Gets the product count for three equal sized prince ranges (cheap, average, expensive) by looking at the difference between the cheapest and the most expensive products.
    /// </summary>
    /// <returns></returns>
    Dictionary<PriceRange, int> GetCountByPriceRange();
}
