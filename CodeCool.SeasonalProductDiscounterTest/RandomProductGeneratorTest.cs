using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
namespace CodeCool.SeasonalProductDiscounterTest;
public class RandomProductGeneratorTest
{
    [Test]
    public void GenerateRandomProducts_CountIsZero_ReturnsEmptyList()
    {
        RandomProductGenerator productProvider = new RandomProductGenerator(0, 100, 500);
        Assert.That(productProvider.Products.Count, Is.EqualTo(0));
    }
    [Test]
    public void GenerateRandomProducts_CountIsZeroMaximumIsLessThanMinimum_ReturnsEmptyList()
    {
        RandomProductGenerator productProvider = new RandomProductGenerator(0, 300, 100);
        Assert.That(productProvider.Products.Count, Is.EqualTo(0));
    }
    [Test]
    public void GenerateRandomProducts_CountAboveZeroMaximumLessThanMinimum_ReturnsEmptyList()
    {
        RandomProductGenerator productProvider = new RandomProductGenerator(10, 300, 100);
        Assert.That(productProvider.Products.Count, Is.EqualTo(0));
    }
    [Test]
    public void GenerateRandomProducts_CountAboveZeroMaximumAboveMinimumWithLessThan1_ReturnsCountListProducts()
    {
        RandomProductGenerator productProvider = new RandomProductGenerator(10, 100, 100.9);
        Assert.That(productProvider.Products.Count, Is.EqualTo(10));
    }
}