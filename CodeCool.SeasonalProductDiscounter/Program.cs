using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui;

var productProvider = new RandomProductGenerator(100, 10, 50);
IProductBrowser productBrowser = null;
IProductStatistics productStatistics = null;

var productsUi = new ProductsUi(productBrowser);
var statisticsUi = new StatisticsUi(productStatistics);

productsUi.Run();
