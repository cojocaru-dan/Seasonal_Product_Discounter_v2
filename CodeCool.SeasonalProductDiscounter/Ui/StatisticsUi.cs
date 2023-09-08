using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class StatisticsUi
{
    private readonly IProductStatistics _productStatistics;

    public StatisticsUi(IProductStatistics productStatistics)
    {
        _productStatistics = productStatistics;
    }

    public void Run()
    {
        foreach (var groupByName in _productStatistics.GetAveragePricesByName())
        {
            Console.WriteLine($"{groupByName.Key}: {groupByName.Value}");
        }
        foreach (var groupByColor in _productStatistics.GetAveragePricesByColor())
        {
            Console.WriteLine($"{groupByColor.Key}: {groupByColor.Value}");
        }
        foreach (var groupBySeason in _productStatistics.GetAveragePricesBySeason())
        {
            Console.WriteLine($"{groupBySeason.Key}: {groupBySeason.Value}");
        }

        foreach (var kvp in _productStatistics.GetCountByName())
        {
            Console.WriteLine("Name: {0}, Count: {1}", kvp.Key, kvp.Value);
        }

        foreach (var kvp in _productStatistics.GetCountByPriceRange())
        {
            Console.WriteLine("PriceRange: {0}, Count: {1}", kvp.Key, kvp.Value);
        }

        Console.WriteLine("The Cheapest Product: {0}", _productStatistics.GetCheapest());
        Console.WriteLine("The  Average Price: {0}", _productStatistics.GetAveragePrice());
    }
}
