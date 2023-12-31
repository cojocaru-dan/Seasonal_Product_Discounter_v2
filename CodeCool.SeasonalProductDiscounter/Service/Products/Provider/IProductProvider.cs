﻿using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

public interface IProductProvider
{
    IEnumerable<Product> Products { get; }
    double MinProductPrice { get; }
    double MaxProductPrice { get; }
}
