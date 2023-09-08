using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

public class ProductStatistics : IProductStatistics
{
    private IProductProvider _productProvider;
    public ProductStatistics(IProductProvider productProvider)
    {
        _productProvider = productProvider;
    }
    public Product? GetMostExpensive() => _productProvider.Products.MaxBy(p => p.Price);
    public Product? GetCheapest() => _productProvider.Products.MinBy(p => p.Price);
    public double GetAveragePrice() => _productProvider.Products.Average(p => p.Price);

    public Dictionary<string, double> GetAveragePricesByName()
    {
        var averagePricesByName = new Dictionary<string, double>();
        var x = _productProvider.Products
            .GroupBy(p => p.Name)
            .Select(g => new { Name = g.Key, Average = g.Average(p => p.Price) });

        foreach (var item in x)
        {
            averagePricesByName.Add(item.Name, item.Average);
        }

        return averagePricesByName;
    }
    public Dictionary<Color, double> GetAveragePricesByColor()
    {
        var averagePricesByColor = new Dictionary<Color, double>();
        var x = _productProvider.Products
            .GroupBy(p => p.Color)
            .Select(g => new { Color = g.Key, Average = g.Average(p => p.Price) });

        foreach (var item in x)
        {
            averagePricesByColor.Add(item.Color, item.Average);
        }

        return averagePricesByColor;
    }
    public Dictionary<Season, double> GetAveragePricesBySeason()
    {
        var averagePricesBySeason = new Dictionary<Season, double>();
        var x = _productProvider.Products
            .GroupBy(p => p.Season)
            .Select(g => new { Season = g.Key, Average = g.Average(p => p.Price) });

        foreach (var item in x)
        {
            averagePricesBySeason.Add(item.Season, item.Average);
        }

        return averagePricesBySeason;
    }

    /// <summary>
    /// Gets the average prices for three equal sized prince ranges (cheap, average, expensive) by looking at the difference between the cheapest and the most expensive products.
    /// </summary>
    /// <returns></returns>
    public Dictionary<PriceRange, double> GetAveragePricesByPriceRange()
    {
        double minimum = _productProvider.MinProductPrice;
        double maximum = _productProvider.MaxProductPrice;
        double unit = (maximum - minimum) / 3;
        List<PriceRange> priceRanges = new List<PriceRange>();

        for (int i = 1; i < 4; i++)
        {
            PriceRange newPriceRange = new PriceRange(minimum + (i - 1) * unit, minimum + i * unit);
            priceRanges.Add(newPriceRange);
        }

        var groupedByRanges =   from product in _productProvider.Products
                                group product by priceRanges.Where(price => price.Contains(product.Price)).First() 
                                into priceGroup
                                select new
                                {
                                    PriceRange = priceGroup.Key,
                                    AveragePrice = priceGroup.Average(product => product.Price)
                                };
        
        var groupedByRangesDict = groupedByRanges.ToDictionary(result => result.PriceRange, result => result.AveragePrice);
        return groupedByRangesDict;
    }

    public Dictionary<string, int> GetCountByName() 
    { 
        var countByName = _productProvider.Products
                            .GroupBy(p => p.Name)
                            .Select(g => new { Name = g.Key, Count = g.Count() });
        var countByNameDict = countByName.ToDictionary(result => result.Name, result => result.Count);
        return countByNameDict; 
    }
    public Dictionary<Color, int> GetCountByColor() 
    {
        var countByColor = _productProvider.Products
                            .GroupBy(p => p.Color)
                            .Select(g => new { Color = g.Key, Count = g.Count() });
        var countByColorDict = countByColor.ToDictionary(result => result.Color, result => result.Count);
        return countByColorDict;
    }
    public Dictionary<Season, int> GetCountBySeason() 
    {
        var countBySeason = _productProvider.Products
                            .GroupBy(p => p.Season)
                            .Select(g => new { Season = g.Key, Count = g.Count() });
        var countBySeasonDict = countBySeason.ToDictionary(result => result.Season, result => result.Count);
        return countBySeasonDict;
    }

    /// <summary>
    /// Gets the product count for three equal sized prince ranges (cheap, average, expensive) by looking at the difference between the cheapest and the most expensive products.
    /// </summary>
    /// <returns></returns>
    public Dictionary<PriceRange, int> GetCountByPriceRange() 
    {
        double minimum = _productProvider.MinProductPrice;
        double maximum = _productProvider.MaxProductPrice;
        double unit = (maximum - minimum) / 3;
        List<PriceRange> priceRanges = new List<PriceRange>();

        for (int i = 1; i < 4; i++)
        {
            PriceRange newPriceRange = new PriceRange(minimum + (i - 1) * unit, minimum + i * unit);
            priceRanges.Add(newPriceRange);
        }

        var groupedByRanges = from product in _productProvider.Products
                              group product by priceRanges.Where(price => price.Contains(product.Price)).First()
                              into priceGroup
                              select new
                              {
                                  PriceRange = priceGroup.Key,
                                  CountProducts = priceGroup.Count()
                              };

        var groupedByRangesDict = groupedByRanges.ToDictionary(result => result.PriceRange, result => result.CountProducts);
        return groupedByRangesDict;
    }
}