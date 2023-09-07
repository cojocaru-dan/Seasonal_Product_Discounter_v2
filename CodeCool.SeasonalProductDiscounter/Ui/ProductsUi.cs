using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class ProductsUi
{
    private readonly IProductBrowser _productBrowser;

    public ProductsUi(IProductBrowser productBrowser)
    {
        _productBrowser = productBrowser;
    }

    public void Run()
    {
        PrintProducts("Shirts", _productBrowser.GetByName("skirt"));
        PrintProducts("Order By Name", _productBrowser.OrderByName());
        PrintProducts("Order By Price", _productBrowser.OrderByPrice());
        PrintProducts("Get By Price Range Between 70 and 80", _productBrowser.GetByPriceRange(70, 80));
    }

    private static void PrintProducts(string text, IEnumerable<Product> products)
    {
        Console.WriteLine($"{text}: ");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}
