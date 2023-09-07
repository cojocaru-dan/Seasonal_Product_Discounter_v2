using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

namespace CodeCool.SeasonalProductDiscounterTest;

public class ProductBrowserTest
{
    private readonly IProductBrowser _productBrowser;
    private readonly RandomProductGenerator _provider;

    private static readonly object[] Names =
    {
        "skirt",
        "T-shirt",
        "jacket",
        "shirt",
        "hat",
        "gloves"
    };
    private static readonly Color[] Colors = Enum.GetValues<Color>();
    private static readonly Season[] Seasons = Enum.GetValues<Season>();

    private static readonly int[] prices = {60, 70, 80};


    public ProductBrowserTest()
    {
        _provider = new RandomProductGenerator(10, 50, 100);
        _productBrowser = new ProductBrowser(_provider);
    }

    [Test]
    public void GetAll_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products;
        var actual = _productBrowser.GetAll();

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [TestCaseSource(nameof(Names))]
    public void GetByName_FilterByName_ReturnsEquivalentCollections(string name)
    {
        var expected = _provider.Products.Where(p => p.Name.Contains(name));
        var actual =_productBrowser.GetByName(name);

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [TestCaseSource(nameof(Colors))]
    public void GetByColor_FilterByColor_ReturnsEquivalentCollections(Color color)
    {
        var expected = _provider.Products.Where(p => p.Color == color);
        var actual = _productBrowser.GetByColor(color);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [TestCaseSource(nameof(Seasons))]
    public void GetBySeason_FilterBySeason_ReturnsEquivalentCollections(Season season)
    {
        var expected = _provider.Products.Where(p => p.Season == season);
        var actual = _productBrowser.GetBySeason(season);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [TestCaseSource(nameof(prices))]
    public void GetByPriceSmallerThan_ProductsPricesSmallerThanPrice_ReturnsEquivalentCollections(double price)
    {
        var expected = _provider.Products.Where(p => p.Price < price);
        var actual = _productBrowser.GetByPriceSmallerThan(price);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [TestCaseSource(nameof(prices))]
    public void GetByPriceGreaterThan_ProductsPricesGreaterThanPrice_ReturnsEquivalentCollections(double price)
    {
        var expected = _provider.Products.Where(p => p.Price > price);
        var actual = _productBrowser.GetByPriceGreaterThan(price);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [TestCase(50, 60)]
    [TestCase(60, 70)]
    [TestCase(70, 80)]
    public void GetByPriceRange_ProductsPricesBetweenRange_ReturnsEquivalentCollections(double minimumPrice, double maximumPrice)
    {
        var expected = _provider.Products.Where(p => p.Price > minimumPrice && p.Price < maximumPrice);
        var actual = _productBrowser.GetByPriceRange(minimumPrice, maximumPrice);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [Test]
    public void GroupByName_ProductsGroupedByName_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products.GroupBy(p => p.Name);
        var actual = _productBrowser.GroupByName();

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [Test]
    public void GroupByColor_ProductsGroupedByColor_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products.GroupBy(p => p.Color);
        var actual = _productBrowser.GroupByColor();

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [Test]
    public void GroupBySeason_ProductsGroupedBySeason_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products.GroupBy(p => p.Season);
        var actual = _productBrowser.GroupBySeason();

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [Test]
    public void GroupByPriceRange_GroupByCheapAverageExpensive_ReturnsEquivalentCollections()
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

        var expectedGroupedProducts = from product in _provider.Products
                                    group product by priceRanges.Where(price => price.Contains(product.Price)).First();
        var actualGroupedProducts = _productBrowser.GroupByPriceRange();

        Assert.That(actualGroupedProducts, Is.EquivalentTo(expectedGroupedProducts));
    }
    [Test]
    public void OrderByName_ProductsOrderedByName_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products.OrderBy(p => p.Name);
        var actual = _productBrowser.OrderByName();

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [Test]
    public void OrderByColor_ProductsOrderedByColor_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products.OrderBy(p => p.Color);
        var actual = _productBrowser.OrderByColor();

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [Test]
    public void OrderBySeason_ProductsOrderedBySeason_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products.OrderBy(p => p.Season);
        var actual = _productBrowser.OrderBySeason();

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    [Test]
    public void OrderByPrice_ProductsOrderedByPrice_ReturnsEquivalentCollections()
    {
        var expected = _provider.Products.OrderBy(p => p.Price);
        var actual = _productBrowser.OrderByPrice();

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
