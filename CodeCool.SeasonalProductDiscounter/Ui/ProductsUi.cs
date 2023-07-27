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

        //...
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
