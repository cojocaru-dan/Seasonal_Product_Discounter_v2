using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui;

var productProvider = new RandomProductGenerator(10, 50, 100);
IProductBrowser productBrowser = new ProductBrowser(productProvider);
// IProductStatistics productStatistics = null;

var productsUi = new ProductsUi(productBrowser);
// var statisticsUi = new StatisticsUi(productStatistics);

productsUi.Run();
// foreach (var product in productProvider.Products)
// {
//     Console.WriteLine(product);
// }
