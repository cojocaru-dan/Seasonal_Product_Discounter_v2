using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

namespace CodeCool.SeasonalProductDiscounterTest;
[TestFixture]
public class ProductStatisticsTest
{
    private readonly RandomProductGenerator _provider;
    private readonly IProductStatistics _statistics;

    public ProductStatisticsTest()
    {
        _provider = new RandomProductGenerator(10, 50, 100);
        _statistics = new ProductStatistics(_provider);
    }

    [Test]
    public void MostExpensive()
    {
        var expected = _provider.Products.MaxBy(p => p.Price);
        var actual = _statistics.GetMostExpensive();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetCheapest()
    {
        var expected = _provider.Products.MinBy(p => p.Price);
        var actual = _statistics.GetCheapest();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetAveragePrice()
    {
        var expected = _provider.Products.Average(p => p.Price);
        var actual = _statistics.GetAveragePrice();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetAveragePricesByName()
    {
        var expected = _provider.Products
            .GroupBy(p => p.Name)
            .Select(g => new { Name = g.Key, Average = g.Average(p => p.Price) })
            .ToDictionary(result => result.Name, result => result.Average);

        var actual = _statistics.GetAveragePricesByName();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetAveragePricesByColor()
    {
        var expected = _provider.Products
            .GroupBy(p => p.Color)
            .Select(g => new { Color = g.Key, Average = g.Average(p => p.Price) })
            .ToDictionary(result => result.Color, result => result.Average);

        var actual = _statistics.GetAveragePricesByColor();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetAveragePricesBySeason()
    {
        var expected = _provider.Products
            .GroupBy(p => p.Season)
            .Select(g => new { Season = g.Key, Average = g.Average(p => p.Price) })
            .ToDictionary(result => result.Season, result => result.Average);

        var actual = _statistics.GetAveragePricesBySeason();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetAveragePricesByPriceRange()
    {
        double minimum = _provider.MinProductPrice;
        double maximum = _provider.MaxProductPrice;
        double unit = (maximum - minimum) / 3;
        List<PriceRange> priceRanges = new List<PriceRange>();

        for (int i = 1; i < 4; i++)
        {
            PriceRange newPriceRange = new PriceRange(minimum + (i - 1) * unit, minimum + i * unit);
            priceRanges.Add(newPriceRange);
        }
        var expected = _provider.Products
            .GroupBy(p => priceRanges.Where(price => price.Contains(p.Price)).First())
            .Select(g => new { PriceRange = g.Key, AveragePrice = g.Average(p => p.Price) })
            .ToDictionary(result => result.PriceRange, result => result.AveragePrice);

        var actual = _statistics.GetAveragePricesByPriceRange();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetCountByName()
    {
        var expected = _provider.Products
            .GroupBy(p => p.Name)
            .Select(g => new { Name = g.Key, Count = g.Count() })
            .ToDictionary(result => result.Name, result => result.Count);

        var actual = _statistics.GetCountByName();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetCountByColor()
    {
        var expected = _provider.Products
            .GroupBy(p => p.Color)
            .Select(g => new { Color = g.Key, Count = g.Count() })
            .ToDictionary(result => result.Color, result => result.Count);

        var actual = _statistics.GetCountByColor();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetCountBySeason()
    {
        var expected = _provider.Products
            .GroupBy(p => p.Season)
            .Select(g => new { Season = g.Key, Count = g.Count() })
            .ToDictionary(result => result.Season, result => result.Count);

        var actual = _statistics.GetCountBySeason();

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void GetCountByPriceRange()
    {
        double minimum = _provider.MinProductPrice;
        double maximum = _provider.MaxProductPrice;
        double unit = (maximum - minimum) / 3;
        List<PriceRange> priceRanges = new List<PriceRange>();

        for (int i = 1; i < 4; i++)
        {
            PriceRange newPriceRange = new PriceRange(minimum + (i - 1) * unit, minimum + i * unit);
            priceRanges.Add(newPriceRange);
        }

        var expected = _provider.Products
            .GroupBy(p => priceRanges.Where(price => price.Contains(p.Price)).First())
            .Select(g => new { PriceRange = g.Key, Count = g.Count() })
            .ToDictionary(result => result.PriceRange, result => result.Count);

        var actual = _statistics.GetCountByPriceRange();

        Assert.That(actual, Is.EqualTo(expected));
    }
}
