using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Browser;

public class ProductBrowser : IProductBrowser
{
    private IProductProvider _productProvider;
    public ProductBrowser(IProductProvider productProvider)
    {
        _productProvider = productProvider;
    }
    public IEnumerable<Product> GetAll() => _productProvider.Products;
    public IEnumerable<Product> GetByName(string name) => _productProvider.Products.Where(p => p.Name.Contains(name));
    public IEnumerable<Product> GetByColor(Color color) => _productProvider.Products.Where(p => p.Color == color);
    public IEnumerable<Product> GetBySeason(Season season) => _productProvider.Products.Where(p => p.Season == season);

    public IEnumerable<Product> GetByPriceSmallerThan(double price) => _productProvider.Products.Where(p => p.Price < price);
    public IEnumerable<Product> GetByPriceGreaterThan(double price) => _productProvider.Products.Where(p => p.Price > price);
    public IEnumerable<Product> GetByPriceRange(double minimumPrice, double maximumPrice) => _productProvider.Products.Where(p => p.Price > minimumPrice && p.Price < maximumPrice);

    public IEnumerable<IGrouping<string, Product>> GroupByName() => _productProvider.Products.GroupBy(p => p.Name);
    public IEnumerable<IGrouping<Color, Product>> GroupByColor() => _productProvider.Products.GroupBy(p => p.Color);
    public IEnumerable<IGrouping<Season, Product>> GroupBySeason() => _productProvider.Products.GroupBy(p => p.Season);

    /// <summary>
    /// Groups the products into three equal sized prince ranges (cheap, average, expensive) by looking at the difference between the cheapest and the most expensive products.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IGrouping<PriceRange, Product>> GroupByPriceRange()
    {
        double minimum = _productProvider.MinProductPrice;
        double maximum = _productProvider.MaxProductPrice;
        double unit = (maximum - minimum) / 3;
        List<PriceRange> priceRanges = new List<PriceRange>();

        for (int i = 1; i < 4; i++)
        {
            PriceRange newPriceRange = new PriceRange(minimum + (i-1) * unit, minimum + i * unit);
            priceRanges.Add(newPriceRange);
        } 
        
        var groupedByRanges = from product in _productProvider.Products
                              group product by priceRanges.Where(price => price.Contains(product.Price)).First();

        return groupedByRanges;
    }

    public IEnumerable<Product> OrderByName() => _productProvider.Products.OrderBy(p => p.Name);
    public IEnumerable<Product> OrderByColor() => _productProvider.Products.OrderBy(p => p.Color);
    public IEnumerable<Product> OrderBySeason() => _productProvider.Products.OrderBy(p => p.Season);
    public IEnumerable<Product> OrderByPrice() => _productProvider.Products.OrderBy(p => p.Price);
}